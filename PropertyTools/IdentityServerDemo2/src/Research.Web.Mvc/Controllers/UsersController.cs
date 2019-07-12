using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Research.Authorization;
using Research.Controllers;
using Research.Users;
using Microsoft.AspNetCore.Mvc;

namespace Research.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ResearchControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}