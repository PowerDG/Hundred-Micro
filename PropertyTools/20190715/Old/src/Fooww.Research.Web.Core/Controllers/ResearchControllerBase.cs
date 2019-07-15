using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Fooww.Research.Controllers
{
    public abstract class ResearchControllerBase: AbpController
    {
        protected ResearchControllerBase()
        {
            LocalizationSourceName = ResearchConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
