using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchDomainSharedModule)
        )]
    public class ResearchDomainModule : AbpModule
    {

    }
}
