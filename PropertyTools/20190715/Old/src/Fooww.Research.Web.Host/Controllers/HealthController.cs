using Fooww.Research.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fooww.Research.Web.Host.Controllers
{
    [Route("api/[Controller]")]
    public class HealthController : ResearchControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "200";
        }
    }
}