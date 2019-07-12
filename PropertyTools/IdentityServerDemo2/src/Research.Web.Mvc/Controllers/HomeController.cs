using Abp.AspNetCore.Mvc.Authorization;
using Research.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Research.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ResearchControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}