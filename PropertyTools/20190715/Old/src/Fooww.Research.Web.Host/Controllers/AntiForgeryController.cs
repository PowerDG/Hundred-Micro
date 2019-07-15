using Microsoft.AspNetCore.Antiforgery;
using Fooww.Research.Controllers;

namespace Fooww.Research.Web.Host.Controllers
{
    public class AntiForgeryController : ResearchControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
