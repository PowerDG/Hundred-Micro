using Fooww.Research.Localization;
using Volo.Abp.Application.Services;

namespace Fooww.Research
{
    public abstract class ResearchAppService : ApplicationService
    {
        protected ResearchAppService()
        {
            LocalizationResource = typeof(ResearchResource);
        }
    }
}
