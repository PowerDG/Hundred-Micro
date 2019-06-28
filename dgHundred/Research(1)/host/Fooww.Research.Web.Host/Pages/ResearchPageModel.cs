using Fooww.Research.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Fooww.Research.Pages
{
    public abstract class ResearchPageModel : AbpPageModel
    {
        protected ResearchPageModel()
        {
            LocalizationResourceType = typeof(ResearchResource);
        }
    }
}