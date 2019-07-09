using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ResearchHome.Areas.Introduction.Models;
using ResearchHome.Controllers;
using ResearchHome.DataBase;
using ResearchHome.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ResearchHome.Areas.Book.Models;

namespace ResearchHome.Areas.Introduction.Controllers
{
    [Area("Introduction")]
    public class ReadBooksController : BaseController
    {
        private readonly IDatabase database;
        private IHostingEnvironment environment;
        private readonly IConfiguration configuration;
        public ReadBooksController(IDatabase database, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.database = database;
            this.environment = hostingEnvironment;
            this.configuration = configuration;
        } 
        public async Task<JsonResult> GetReadBooks(int memberId, int page, int limit)
        {
            string sql = $@"SELECT book_comment.id AS Id,book.`Name` AS Name,book.Photo,book.PhotoHD,book.Author,
                        book_comment.create_time ,book_comment.member_id AS MemberId,book_comment.`comment` AS Commentary
                         FROM book_comment,book WHERE member_id ={memberId} AND book_comment.book_id=book.Id 
                          ORDER BY create_time DESC LIMIT {(page - 1) * limit}, {limit}";
            var records = database.QueryListSQL<ReadBooks>(sql).ToList();
            string sqlCount = $"SELECT COUNT(*) AS Count FROM book_comment WHERE member_id= {memberId}";
            var count = await database.ExecuteScalarAsync(sqlCount);
            return Json(new { code = 0, msg = "查询成功", count, data = records });
        } 


        [HttpPost]
        public async Task<JsonResult> CommentExtraBook(BookModel m_extraBook)
        {

            BookModel book = m_extraBook; 
            string comment = book.LastComment;

            int score = 5, m_bookId = book.Id;


            #region AddBookExtra
            bool result = false; 
            if (!string.IsNullOrEmpty(book.Photo))
            {
                var photo = PictureHelper.UploadPicture("FileUpload", book.Photo, configuration, environment);
                book.Photo = photo.Item2;
                book.PhotoHD = photo.Item1;
            }

            var memberId = GetCurrentUserClaim("Id");

            if (book.Id > 0)
            {


                string sql = $@"SELECT * FROM book where book.Id=
                        ( select 	book_id FROM book_comment
                        where 	book_comment.member_id= {memberId}
                          AND   book_comment.book_id={book.Id}
                        )";
                var m_book = database.Single<BookModel>(sql);
                if (m_book == null || m_book.State != AppLtmConsts.BookType_CommentExtra)
                {
                    return Json(new { success = result, message = "您无权删除该书评" });
                }




                System.Text.StringBuilder m_sql = new System.Text.StringBuilder($"UPDATE book SET Name = '{book.Name}', Author = '{book.Author}', last_comment = '{book.LastComment}' ");
                if (!string.IsNullOrEmpty(book.Photo))
                {
                    m_sql.Append($", Photo = '{book.Photo}', PhotoHD = '{book.PhotoHD}'");
                }
                m_sql.Append($" WHERE Id = {book.Id}");
                result = database.ExecuteSQL(m_sql.ToString());
            }
            else
            {
                book.CreateTime = DateTime.Now;
                book.State = AppLtmConsts.BookType_CommentExtra;

                var m_bookById = await database.CreateAsync<BookModel>(book);
                  result = m_bookById > 0;

                if (!result)
                {
                    return Json(new { success = result, message = "操作失败" });
                }

                #region AddCommnet  
                //    score=(m_extraBook.score==0)?5: m_extraBook.score;
                //string comment= String.IsNullOrWhiteSpace(m_extraBook.comment)?
                //    "默认好评": m_extraBook.comment;

                if (comment.Length < 1 || score < 1)
                {
                    return Json(new { result = false, msg = "一点评价都没有，你确定读过了？" });
                }
                string submitComment = $@"INSERT INTO book_comment SET book_id={m_bookId},member_id={memberId},
                                                               comment='{comment}',score={score}";
                result = database.ExecuteSQL(submitComment);

                #endregion
            }


            if (!result)
            {
                return Json(new { success = result, message =  "操作失败" });
            }

            #endregion

         

            #region resultOf Comment-score

             
                string scoreSql = $@"SELECT score FROM book_comment WHERE book_id={m_bookId}";
                List<dynamic> scores = database.QueryListSQL<dynamic>(scoreSql).ToList();
                int totalScore = 0;

                foreach (var itemscore in scores)
                {
                    totalScore += itemscore.score;
                }
                score = (totalScore + score) / (scores.Count + 1);
                string bookSql = $@"UPDATE book SET last_comment='{comment}',average_score={score},
                                                state={AppLtmConsts.BookType_CommentExtra},MemberId=0 WHERE Id={m_bookId}";
                result = database.ExecuteSQL(bookSql);
             
            #endregion

            //calculate

            return Json(new { Result = result });
        }



        public IActionResult EditReadBook(int memberId, int bookId)
        {
            //ViewBag.MemberId = memberId;
            //string querySQL = $"SELECT * FROM book WHERE id = {bookId}";

            //var memberId = GetCurrentUserClaim("Id");

            string sql = $@"SELECT * FROM book where book.Id=
                        ( select 	book_id FROM book_comment
                        where 	book_comment.member_id= {memberId}
                          AND   book_comment.id={bookId}
                        )";
            var book = database.Single<BookModel>(sql);
            return View(book);
        }




        [HttpPost]
        public async Task<JsonResult> EditReadBook(BookModel book)
        {
             
            bool result = false; 

            //ViewBag.MemberId = memberId;



            var memberId = GetCurrentUserClaim("Id");

            string sql = $@"SELECT * FROM book where book.Id=
                        ( select 	book_id FROM book_comment
                        where 	book_comment.member_id= {memberId}
                          AND   book_comment.id={book.Id}
                        )";
            var m_bookResult = database.Single<BookModel>(sql);
            if (m_bookResult == null || book.State != AppLtmConsts.BookType_CommentExtra)
            {
                return Json(new { success = result, message = "您无权删除该书评" });
            } 

            if (!string.IsNullOrEmpty(book.Photo))
            {
                var photo = PictureHelper.UploadPicture("FileUpload", book.Photo, configuration, environment);
                book.Photo = photo.Item2;
                book.PhotoHD = photo.Item1;
            }
            if (book.Id > 0)
            {
                System.Text.StringBuilder m_sql = new System.Text.StringBuilder($"UPDATE book SET Name = '{book.Name}', Author = '{book.Author}', Commentary = '{book.LastComment}' ");
                if (!string.IsNullOrEmpty(book.Photo))
                {
                    m_sql.Append($", Photo = '{book.Photo}', PhotoHD = '{book.PhotoHD}'");
                }
                m_sql.Append($" WHERE Id = {book.Id}");
                result = database.ExecuteSQL(sql.ToString());
            }
            else
            {

                BookModel m_book = Mapper.Map<BookModel>(book);
                m_book.CreateTime = DateTime.Now;
                m_book.LastComment = book.LastComment;
                result = await database.CreateAsync<BookModel>(m_book) > 0;
            }
            return Json(new { success = result, message = result ? "操作成功" : "操作失败" });
        }



        [HttpPost]
        public async Task<JsonResult> AddBook(BookModel book)
        {
            bool result = false;
            if (!ModelState.IsValid)
            {
                return Json(new { result, msg = "请填写正确的信息！" });
            }
            if (!string.IsNullOrEmpty(book.Photo))
            {
                var photo = PictureHelper.UploadPicture("FileUpload", book.Photo, configuration, environment);
                book.Photo = photo.Item2;
                book.PhotoHD = photo.Item1;
            }
            if (book.Id > 0)
            {
                System.Text.StringBuilder sql = new System.Text.StringBuilder(
                               $"UPDATE book SET Name = '{book.Name}', Author = '{book.Author}', resource = '{book.Resource}' ");
                if (!string.IsNullOrEmpty(book.Photo))
                {
                    sql.Append($", Photo = '{book.Photo}', PhotoHD = '{book.PhotoHD}'");
                }
                sql.Append($" WHERE Id = {book.Id}");
                result = database.ExecuteSQL(sql.ToString());
            }
            else
            {
                book.CreateTime = DateTime.Now;
                result = await database.CreateAsync<BookModel>(book) > 0;
            }
            return Json(new { Result = result, Msg = "成功" });
        }



        [HttpPost]
        public JsonResult DeleteBook(int id)
        {
            bool result = false;

            //ViewBag.MemberId = memberId;



            var memberId = GetCurrentUserClaim("Id");

            string sql = $@"SELECT * FROM book where book.Id=
                        ( select 	book_id FROM book_comment
                        where 	book_comment.member_id= {memberId}
                          AND   book_comment.id={id}
                        )";
            var book = database.Single<BookModel>(sql);
            if (book == null|| book.State!= AppLtmConsts.BookType_CommentExtra)
            {
                return Json(new { success = result, message = "您无权删除该书评" });
            }

            sql = $@"DELETE FROM book 	
	                        WHERE sta book.Id={book.Id}";
            result = database.ExecuteSQL(sql);
            if (!result)
            {
                return Json(new { success = result, message = "操作失败" });
            }
            sql = $@"DELETE FROM book_comment 
                        WHERE  book_comment.id= {id}"; 
            result = database.ExecuteSQL(sql);

            return Json(new { success = result, message = result ? "删除成功" : "删除失败" });
        }
    }
}