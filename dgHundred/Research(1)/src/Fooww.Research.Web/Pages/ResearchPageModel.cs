using Fooww.Research.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Fooww.Research.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ResearchPageModel : AbpPageModel
    {
        protected ResearchPageModel()
        {
            LocalizationResourceType = typeof(ResearchResource);
        }
    }
}