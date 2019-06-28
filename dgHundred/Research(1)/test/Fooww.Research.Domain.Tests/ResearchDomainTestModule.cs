using Fooww.Research.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Fooww.Research
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ResearchEntityFrameworkCoreTestModule)
        )]
    public class ResearchDomainTestModule : AbpModule
    {
        
    }
}
