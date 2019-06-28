using Fooww.Research.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Fooww.Research
{
    public abstract class ResearchController : AbpController
    {
        protected ResearchController()
        {
            LocalizationResource = typeof(ResearchResource);
        }
    }
}
