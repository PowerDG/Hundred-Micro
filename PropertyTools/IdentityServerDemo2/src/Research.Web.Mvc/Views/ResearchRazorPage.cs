using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Research.Web.Views
{
    public abstract class ResearchRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ResearchRazorPage()
        {
            LocalizationSourceName = ResearchConsts.LocalizationSourceName;
        }
    }
}
