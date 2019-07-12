using Abp.AspNetCore.Mvc.Authorization;
using Research.Authorization;
using Research.Controllers;
using Research.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace Research.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : ResearchControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}