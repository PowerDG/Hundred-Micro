using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Fooww.Research.Authorization;

namespace Fooww.Research
{
    [DependsOn(
        typeof(ResearchCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ResearchApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ResearchAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ResearchApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
