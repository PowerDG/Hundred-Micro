using System;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Configuration.Startup;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Research.EntityFrameworkCore;
using Research.Tests.DependencyInjection;
using Castle.MicroKernel.Registration;
using NSubstitute;

namespace Research.Tests
{
    [DependsOn(
        typeof(ResearchApplicationModule),
        typeof(ResearchEntityFrameworkModule),
        typeof(AbpTestBaseModule)
        )]
    public class ResearchTestModule : AbpModule
    {
        public ResearchTestModule(ResearchEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);

            //Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator>();

            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}