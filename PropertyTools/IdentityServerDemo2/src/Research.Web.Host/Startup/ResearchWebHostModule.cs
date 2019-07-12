using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Research.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Research.Web.Host.Startup
{
    [DependsOn(
       typeof(ResearchWebCoreModule))]
    public class ResearchWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ResearchWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ResearchWebHostModule).GetAssembly());
        }
    }
}
