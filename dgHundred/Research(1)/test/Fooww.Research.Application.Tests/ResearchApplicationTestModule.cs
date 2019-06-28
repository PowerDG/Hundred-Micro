using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchApplicationModule),
        typeof(ResearchDomainTestModule)
        )]
    public class ResearchApplicationTestModule : AbpModule
    {

    }
}
