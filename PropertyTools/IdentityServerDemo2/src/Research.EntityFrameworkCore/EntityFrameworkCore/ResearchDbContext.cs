using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Research.Authorization.Roles;
using Research.Authorization.Users;
using Research.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization.Users;
using Abp.Auditing;
using Abp.Authorization.Roles;
using Abp.Authorization;
using Abp.EntityHistory;
using Abp.Configuration;
using Abp.Application.Editions;
using Abp.BackgroundJobs;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.Application.Features;

namespace Research.EntityFrameworkCore
{
    public class ResearchDbContext : AbpZeroDbContext<Tenant, Role, User, ResearchDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */

        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public ResearchDbContext(DbContextOptions<ResearchDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            #region MyRegion















            modelBuilder.Entity<AuditLog>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<AuditLog>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<AuditLog>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<AuditLog>().Property(t => t.ServiceName).HasColumnName("service_name");
            modelBuilder.Entity<AuditLog>().Property(t => t.MethodName).HasColumnName("method_name");
            modelBuilder.Entity<AuditLog>().Property(t => t.Parameters).HasColumnName("parameters");
            modelBuilder.Entity<AuditLog>().Property(t => t.ReturnValue).HasColumnName("return_value");
            modelBuilder.Entity<AuditLog>().Property(t => t.ExecutionTime).HasColumnName("execution_time");
            modelBuilder.Entity<AuditLog>().Property(t => t.ExecutionDuration).HasColumnName("execution_duration");
            modelBuilder.Entity<AuditLog>().Property(t => t.ClientIpAddress).HasColumnName("client_ip_address");
            modelBuilder.Entity<AuditLog>().Property(t => t.ClientName).HasColumnName("client_name");
            modelBuilder.Entity<AuditLog>().Property(t => t.BrowserInfo).HasColumnName("browser_info");
            modelBuilder.Entity<AuditLog>().Property(t => t.Exception).HasColumnName("exception");
            modelBuilder.Entity<AuditLog>().Property(t => t.ImpersonatorUserId).HasColumnName("impersonator_user_id");
            modelBuilder.Entity<AuditLog>().Property(t => t.ImpersonatorTenantId).HasColumnName("impersonator_tenant_id");
            modelBuilder.Entity<AuditLog>().Property(t => t.CustomData).HasColumnName("custom_data");

            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.JobType).HasColumnName("job_type");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.JobArgs).HasColumnName("job_args");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.TryCount).HasColumnName("try_count");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.NextTryTime).HasColumnName("next_try_time");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.LastTryTime).HasColumnName("last_try_time");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.IsAbandoned).HasColumnName("is_abandoned");
            modelBuilder.Entity<BackgroundJobInfo>().Property(t => t.Priority).HasColumnName("priority");

            modelBuilder.Entity<Edition>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<Edition>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<Edition>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<Edition>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<Edition>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<Edition>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<Edition>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<Edition>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<Edition>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<Edition>().Property(t => t.DisplayName).HasColumnName("display_name");

            modelBuilder.Entity<EntityChangeSet>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<EntityChangeSet>().Property(t => t.BrowserInfo).HasColumnName("browser_info");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.ClientIpAddress).HasColumnName("client_ip_address");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.ClientName).HasColumnName("client_name");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.ExtensionData).HasColumnName("extension_data");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.ImpersonatorTenantId).HasColumnName("impersonator_tenant_id");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.ImpersonatorUserId).HasColumnName("impersonator_user_id");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.Reason).HasColumnName("reason");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<EntityChangeSet>().Property(t => t.UserId).HasColumnName("user_id");




            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.DisplayName).HasColumnName("display_name");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.Icon).HasColumnName("icon");
            modelBuilder.Entity<ApplicationLanguage>().Property(t => t.IsDisabled).HasColumnName("is_disabled");



            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.LanguageName).HasColumnName("language_name");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.Source).HasColumnName("source");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.Key).HasColumnName("key");
            modelBuilder.Entity<ApplicationLanguageText>().Property(t => t.Value).HasColumnName("value");




            modelBuilder.Entity<NotificationInfo>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.NotificationName).HasColumnName("notification_name");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.Data).HasColumnName("data");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.DataTypeName).HasColumnName("data_type_name");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.EntityTypeName).HasColumnName("entity_type_name");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.EntityTypeAssemblyQualifiedName).HasColumnName("entity_type_assembly_qualified_name");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.EntityId).HasColumnName("entity_id");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.Severity).HasColumnName("severity");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.UserIds).HasColumnName("user_ids");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.ExcludedUserIds).HasColumnName("excluded_user_ids");
            modelBuilder.Entity<NotificationInfo>().Property(t => t.TenantIds).HasColumnName("tenant_ids");



            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.NotificationName).HasColumnName("notification_name");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.EntityTypeName).HasColumnName("entity_type_name");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.EntityTypeAssemblyQualifiedName).HasColumnName("entity_type_assembly_qualified_name");
            modelBuilder.Entity<NotificationSubscriptionInfo>().Property(t => t.EntityId).HasColumnName("entity_id");



            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.RoleId).HasColumnName("role_id");
            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.OrganizationUnitId).HasColumnName("organization_unit_id");
            modelBuilder.Entity<OrganizationUnitRole>().Property(t => t.IsDeleted).HasColumnName("is_deleted");



            modelBuilder.Entity<OrganizationUnit>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<OrganizationUnit>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.ParentId).HasColumnName("parent_id");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.Code).HasColumnName("code");
            modelBuilder.Entity<OrganizationUnit>().Property(t => t.DisplayName).HasColumnName("display_name");




            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.Type).HasColumnName("type");
            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.SubjectId).HasColumnName("subject_id");
            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.ClientId).HasColumnName("client_id");
            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.Expiration).HasColumnName("expiration");
            modelBuilder.Entity<PersistedGrantEntity>().Property(t => t.Data).HasColumnName("data");





            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.NotificationName).HasColumnName("notification_name");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.Data).HasColumnName("data");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.DataTypeName).HasColumnName("data_type_name");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.EntityTypeName).HasColumnName("entity_type_name");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.EntityTypeAssemblyQualifiedName).HasColumnName("entity_type_assembly_qualified_name");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.EntityId).HasColumnName("entity_id");
            modelBuilder.Entity<TenantNotificationInfo>().Property(t => t.Severity).HasColumnName("severity");



            modelBuilder.Entity<UserAccount>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserAccount>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<UserAccount>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<UserAccount>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<UserAccount>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<UserAccount>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<UserAccount>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<UserAccount>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<UserAccount>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserAccount>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserAccount>().Property(t => t.UserLinkId).HasColumnName("user_link_id");
            modelBuilder.Entity<UserAccount>().Property(t => t.UserName).HasColumnName("user_name");
            modelBuilder.Entity<UserAccount>().Property(t => t.EmailAddress).HasColumnName("email_address");










            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.TenancyName).HasColumnName("tenancy_name");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.UserNameOrEmailAddress).HasColumnName("user_name_or_email_address");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.ClientIpAddress).HasColumnName("client_ip_address");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.ClientName).HasColumnName("client_name");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.BrowserInfo).HasColumnName("browser_info");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.Result).HasColumnName("result");
            modelBuilder.Entity<UserLoginAttempt>().Property(t => t.CreationTime).HasColumnName("create_time");










            modelBuilder.Entity<UserNotificationInfo>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<UserNotificationInfo>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserNotificationInfo>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserNotificationInfo>().Property(t => t.TenantNotificationId).HasColumnName("tenant_notification_id");
            modelBuilder.Entity<UserNotificationInfo>().Property(t => t.State).HasColumnName("state");
            modelBuilder.Entity<UserNotificationInfo>().Property(t => t.CreationTime).HasColumnName("create_time");










            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.OrganizationUnitId).HasColumnName("organization_unit_id");
            modelBuilder.Entity<UserOrganizationUnit>().Property(t => t.IsDeleted).HasColumnName("is_deleted");










            modelBuilder.Entity<User>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<User>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<User>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<User>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<User>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<User>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<User>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<User>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<User>().Property(t => t.AuthenticationSource).HasColumnName("authentication_source");
            modelBuilder.Entity<User>().Property(t => t.UserName).HasColumnName("user_name");
            modelBuilder.Entity<User>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<User>().Property(t => t.EmailAddress).HasColumnName("email_address");
            modelBuilder.Entity<User>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(t => t.Surname).HasColumnName("surname");
            modelBuilder.Entity<User>().Property(t => t.Password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(t => t.EmailConfirmationCode).HasColumnName("email_confirmation_code");
            modelBuilder.Entity<User>().Property(t => t.PasswordResetCode).HasColumnName("password_reset_code");
            modelBuilder.Entity<User>().Property(t => t.LockoutEndDateUtc).HasColumnName("lockout_end_date_utc");
            modelBuilder.Entity<User>().Property(t => t.AccessFailedCount).HasColumnName("access_failed_count");
            modelBuilder.Entity<User>().Property(t => t.IsLockoutEnabled).HasColumnName("is_lockout_enabled");
            modelBuilder.Entity<User>().Property(t => t.PhoneNumber).HasColumnName("phone_number");
            modelBuilder.Entity<User>().Property(t => t.IsPhoneNumberConfirmed).HasColumnName("is_phone_number_confirmed");
            modelBuilder.Entity<User>().Property(t => t.SecurityStamp).HasColumnName("security_stamp");
            modelBuilder.Entity<User>().Property(t => t.IsTwoFactorEnabled).HasColumnName("is_two_factor_enabled");
            modelBuilder.Entity<User>().Property(t => t.IsEmailConfirmed).HasColumnName("is_email_confirmed");
            modelBuilder.Entity<User>().Property(t => t.IsActive).HasColumnName("is_active");
            modelBuilder.Entity<User>().Property(t => t.NormalizedUserName).HasColumnName("normalized_user_name");
            modelBuilder.Entity<User>().Property(t => t.NormalizedEmailAddress).HasColumnName("normalized_email_address");
            modelBuilder.Entity<User>().Property(t => t.ConcurrencyStamp).HasColumnName("concurrency_stamp");





            modelBuilder.Entity<FeatureSetting>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<FeatureSetting>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<FeatureSetting>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<FeatureSetting>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<FeatureSetting>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<FeatureSetting>().Property(t => t.Value).HasColumnName("value");
            //modelBuilder.Entity<FeatureSetting>().Property(t => t.Discriminator).HasColumnName("discriminator");
            //modelBuilder.Entity<FeatureSetting>().Property(t => t.EditionId).HasColumnName("edition_id");
















            modelBuilder.Entity<EntityChange>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<EntityChange>().Property(t => t.ChangeTime).HasColumnName("change_time");
            modelBuilder.Entity<EntityChange>().Property(t => t.ChangeType).HasColumnName("change_type");
            modelBuilder.Entity<EntityChange>().Property(t => t.EntityChangeSetId).HasColumnName("entity_change_set_id");
            modelBuilder.Entity<EntityChange>().Property(t => t.EntityId).HasColumnName("entity_id");
            modelBuilder.Entity<EntityChange>().Property(t => t.EntityTypeFullName).HasColumnName("entity_type_full_name");
            modelBuilder.Entity<EntityChange>().Property(t => t.TenantId).HasColumnName("tenant_id");





            modelBuilder.Entity<Role>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<Role>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<Role>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<Role>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<Role>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<Role>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<Role>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<Role>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<Role>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<Role>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<Role>().Property(t => t.DisplayName).HasColumnName("display_name");
            modelBuilder.Entity<Role>().Property(t => t.IsStatic).HasColumnName("is_static");
            modelBuilder.Entity<Role>().Property(t => t.IsDefault).HasColumnName("is_default");
            modelBuilder.Entity<Role>().Property(t => t.NormalizedName).HasColumnName("normalized_name");
            modelBuilder.Entity<Role>().Property(t => t.ConcurrencyStamp).HasColumnName("concurrency_stamp");





            modelBuilder.Entity<Setting>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<Setting>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<Setting>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<Setting>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<Setting>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<Setting>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<Setting>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Setting>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<Setting>().Property(t => t.Value).HasColumnName("value");




            modelBuilder.Entity<Tenant>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<Tenant>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<Tenant>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<Tenant>().Property(t => t.LastModificationTime).HasColumnName("modified_time");
            modelBuilder.Entity<Tenant>().Property(t => t.LastModifierUserId).HasColumnName("last_modifier_user_id");
            modelBuilder.Entity<Tenant>().Property(t => t.IsDeleted).HasColumnName("is_deleted");
            modelBuilder.Entity<Tenant>().Property(t => t.DeleterUserId).HasColumnName("deleter_user_id");
            modelBuilder.Entity<Tenant>().Property(t => t.DeletionTime).HasColumnName("deleted_time");
            modelBuilder.Entity<Tenant>().Property(t => t.TenancyName).HasColumnName("tenancy_name");
            modelBuilder.Entity<Tenant>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<Tenant>().Property(t => t.ConnectionString).HasColumnName("connection_string");
            modelBuilder.Entity<Tenant>().Property(t => t.IsActive).HasColumnName("is_active");
            modelBuilder.Entity<Tenant>().Property(t => t.EditionId).HasColumnName("edition_id");



            modelBuilder.Entity<UserClaim>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserClaim>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<UserClaim>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<UserClaim>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserClaim>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserClaim>().Property(t => t.ClaimType).HasColumnName("claim_type");
            modelBuilder.Entity<UserClaim>().Property(t => t.ClaimValue).HasColumnName("claim_value");





            modelBuilder.Entity<UserLogin>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserLogin>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserLogin>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserLogin>().Property(t => t.LoginProvider).HasColumnName("login_provider");
            modelBuilder.Entity<UserLogin>().Property(t => t.ProviderKey).HasColumnName("provider_key");






            modelBuilder.Entity<UserRole>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserRole>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<UserRole>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<UserRole>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserRole>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserRole>().Property(t => t.RoleId).HasColumnName("role_id");






            modelBuilder.Entity<UserToken>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<UserToken>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<UserToken>().Property(t => t.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserToken>().Property(t => t.LoginProvider).HasColumnName("login_provider");
            modelBuilder.Entity<UserToken>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<UserToken>().Property(t => t.Value).HasColumnName("value");
            modelBuilder.Entity<UserToken>().Property(t => t.ExpireDate).HasColumnName("expire_date");






            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.EntityChangeId).HasColumnName("entity_change_id");
            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.NewValue).HasColumnName("new_value");
            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.OriginalValue).HasColumnName("original_value");
            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.PropertyName).HasColumnName("property_name");
            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.PropertyTypeFullName).HasColumnName("property_type_full_name");
            modelBuilder.Entity<EntityPropertyChange>().Property(t => t.TenantId).HasColumnName("tenant_id");



            modelBuilder.Entity<PermissionSetting>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<PermissionSetting>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<PermissionSetting>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<PermissionSetting>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<PermissionSetting>().Property(t => t.Name).HasColumnName("name");
            modelBuilder.Entity<PermissionSetting>().Property(t => t.IsGranted).HasColumnName("is_granted");
            //modelBuilder.Entity<PermissionSetting>().Property(t => t.Discriminator).HasColumnName("discriminator");
            modelBuilder.Entity<RolePermissionSetting>().Property(t => t.RoleId).HasColumnName("role_id");
            modelBuilder.Entity<UserPermissionSetting>().Property(t => t.UserId).HasColumnName("user_id");





            modelBuilder.Entity<RoleClaim>().Property(t => t.Id).HasColumnName("id");

            modelBuilder.Entity<RoleClaim>().Property(t => t.CreationTime).HasColumnName("create_time");
            modelBuilder.Entity<RoleClaim>().Property(t => t.CreatorUserId).HasColumnName("creator_user_id");
            modelBuilder.Entity<RoleClaim>().Property(t => t.TenantId).HasColumnName("tenant_id");
            modelBuilder.Entity<RoleClaim>().Property(t => t.RoleId).HasColumnName("role_id");
            modelBuilder.Entity<RoleClaim>().Property(t => t.ClaimType).HasColumnName("claim_type");
            modelBuilder.Entity<RoleClaim>().Property(t => t.ClaimValue).HasColumnName("claim_value");




            #endregion

            modelBuilder.ConfigurePersistedGrantEntity();


        }

        
    }
}
