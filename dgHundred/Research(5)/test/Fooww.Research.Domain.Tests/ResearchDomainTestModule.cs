using Fooww.Research.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchEntityFrameworkCoreTestModule)
        )]
    public class ResearchDomainTestModule : AbpModule
    {

    }
}