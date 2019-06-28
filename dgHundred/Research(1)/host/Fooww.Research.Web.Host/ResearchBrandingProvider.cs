using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Fooww.Research
{
    [Dependency(ReplaceServices = true)]
    public class ResearchBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Research";
    }
}
