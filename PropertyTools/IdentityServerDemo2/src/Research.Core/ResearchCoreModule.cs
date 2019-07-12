using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Research.Localization;
using Abp.Zero.Configuration;
using Research.MultiTenancy;
using Research.Authorization.Roles;
using Research.Authorization.Users;
using Research.Configuration;
using Research.Timing;

namespace Research
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class ResearchCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            ResearchLocalizationConfigurer.Configure(Configuration.Localization);

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = ResearchConsts.MultiTenancyEnabled;

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ResearchCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}