using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Research.Authorization;

namespace Research
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
            IocManager.RegisterAssemblyByConvention(typeof(ResearchApplicationModule).GetAssembly());
        }
    }
}