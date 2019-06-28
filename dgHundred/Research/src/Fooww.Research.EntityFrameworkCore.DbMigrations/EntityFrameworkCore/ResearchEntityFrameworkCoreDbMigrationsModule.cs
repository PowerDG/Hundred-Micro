using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Fooww.Research.EntityFrameworkCore
{
    [DependsOn(
        typeof(ResearchEntityFrameworkCoreModule)
        )]
    public class ResearchEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ResearchMigrationsDbContext>();
        }
    }
}
