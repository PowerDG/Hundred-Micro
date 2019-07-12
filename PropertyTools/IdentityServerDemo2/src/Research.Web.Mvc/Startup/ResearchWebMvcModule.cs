using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Research.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Research.Web.Startup
{
    [DependsOn(typeof(ResearchWebCoreModule))]
    public class ResearchWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ResearchWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<ResearchNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ResearchWebMvcModule).GetAssembly());
        }
    }
}