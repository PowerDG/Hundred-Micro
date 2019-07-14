using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Research.Extensions;

namespace Research.Controllers
{
    public abstract class ResearchControllerBase: AbpController
    {
        //隐藏父类的AbpSession
        //public new IAbpSessionExtension AbpSession { get; set; }
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