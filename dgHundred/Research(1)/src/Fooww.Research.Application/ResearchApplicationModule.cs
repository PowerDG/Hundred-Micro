﻿using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchDomainModule),
        typeof(ResearchApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ResearchApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                /* Using `true` for the `validate` parameter to
                 * validate the profile on application startup.
                 * See http://docs.automapper.org/en/stable/Configuration-validation.html for more info
                 * about the configuration validation. */
                options.AddProfile<ResearchApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
