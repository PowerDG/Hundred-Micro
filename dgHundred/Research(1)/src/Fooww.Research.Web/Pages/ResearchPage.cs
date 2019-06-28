using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Fooww.Research.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Fooww.Research.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Fooww.Research.Web.Pages.ResearchPage
     */
    public abstract class ResearchPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<ResearchResource> L { get; set; }
    }
}
