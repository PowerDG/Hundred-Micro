using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CamelTo_under_score;
using OfficeOpenXml;

namespace Camel2mysqlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ShowCamelName();
            string filePath = "";
            filePath =@"E:\GitHub\github.PowerDG\DDDgP2018\4.6.0\Three\DB\resultkey.csv";
            //List<string[]> a= CSVFileHelper.OpenCSV2List(filePath);


        }


        public void Contact()
        {
            //var path = Path.Combine(HostingEnvironment.WebRootPath, "excel", "abc.xlsx");
            //using (var fs = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
            //using (var package = new ExcelPackage(fs))
            //{
            //    var worksheet = package.Workbook.Worksheets["Inventory"];

            //    var sc = worksheet.Dimension.Start.Column;
            //    var ec = worksheet.Dimension.End.Column;
            //    var sr = worksheet.Dimension.Start.Row;
            //    var er = worksheet.Dimension.End.Row;
            //    var value = worksheet.Cells[sc, sr + 1].Value;
            //}


            
        }
        public void ShowCamelName()
        {

            string m_input = Console.ReadLine().ToString();
            string m_output = NamingConventions.UnderscoreName(m_input);
            Console.WriteLine(m_output);


            //DataTable dt = CSVFileHelper.OpenCSV(filePath);
            ////OpenCSV

            //foreach (DataRow dr2 in dt.Rows)
            //{
            //    //.Write(dr2["kjny"].ToString() + "<br>");
            //    Console.WriteLine(dr2[3]);
            //}
        }
    }
}
