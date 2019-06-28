using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ResearchHttpApiModule : AbpModule
    {
        
    }
}
