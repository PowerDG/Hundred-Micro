using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Fooww.Research.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(ResearchHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ResearchConsoleApiClientModule : AbpModule
    {
        
    }
}
