using Research.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Research.Web.Controllers
{
    public class AboutController : ResearchControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}