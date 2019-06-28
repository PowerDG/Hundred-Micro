using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ResearchHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Research";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ResearchApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
