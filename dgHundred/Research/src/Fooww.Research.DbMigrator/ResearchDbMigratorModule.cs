using Fooww.Research.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Fooww.Research.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ResearchEntityFrameworkCoreDbMigrationsModule),
        typeof(ResearchApplicationContractsModule)
        )]
    public class ResearchDbMigratorModule : AbpModule
    {
        
    }
}
