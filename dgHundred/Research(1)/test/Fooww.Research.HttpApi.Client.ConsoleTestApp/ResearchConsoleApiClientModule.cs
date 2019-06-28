using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ResearchConsoleApiClientModule : AbpModule
    {
        
    }
}
