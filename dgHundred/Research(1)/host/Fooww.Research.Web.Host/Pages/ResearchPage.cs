using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Fooww.Research.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Fooww.Research.Pages
{
    public abstract class ResearchPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<ResearchResource> L { get; set; }
    }
}
