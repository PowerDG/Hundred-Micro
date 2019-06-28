using Fooww.Research.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Fooww.Research.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ResearchController : AbpController
    {
        protected ResearchController()
        {
            LocalizationResource = typeof(ResearchResource);
        }
    }
}