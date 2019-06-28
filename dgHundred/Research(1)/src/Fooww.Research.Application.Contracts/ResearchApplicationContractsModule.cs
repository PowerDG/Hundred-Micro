using Fooww.Research.Localization;
using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class ResearchApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ResearchApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ResearchResource>()
                    .AddVirtualJson("/Localization/Research/ApplicationContracts");
            });
        }
    }
}
