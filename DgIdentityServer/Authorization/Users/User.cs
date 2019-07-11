using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace Research.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }

        #region MyRegion
        [Column("id")]
        public new long Id { get; set; }
        [Column("creator_user_id")]
        public new long? CreatorUserId { get; set; }
        [Column("last_modifier_user_id")]
        public new long? LastModifierUserId { get; set; }
        [Column("is_deleted")]
        public new bool IsDeleted { get; set; }
        [Column("deleter_user_id")]
        public new long? DeleterUserId { get; set; }
        [Column("deleted_time")]
        public new DateTime? DeletionTime { get; set; }
        [Column("authentication_source")]
        public new string AuthenticationSource { get; set; }
        [Column("user_name")]
        public new string UserName { get; set; }
        [Column("tenant_id")]
        public new int? TenantId { get; set; }
        [Column("email_address")]
        public new string EmailAddress { get; set; }
        [Column("name")]
        public new string Name { get; set; }
        [Column("surname")]
        public new string Surname { get; set; }
        [Column("password")]
        public new string Password { get; set; }
        [Column("email_confirmation_code")]
        public new string EmailConfirmationCode { get; set; }
        [Column("password_reset_code")]
        public new string PasswordResetCode { get; set; }
        [Column("lockout_end_date_utc")]
        public new DateTime? LockoutEndDateUtc { get; set; }
        [Column("access_failed_count")]
        public new int AccessFailedCount { get; set; }
        [Column("is_lockout_enabled")]
        public new bool IsLockoutEnabled { get; set; }
        [Column("phone_number")]
        public new string PhoneNumber { get; set; }
        [Column("is_phone_number_confirmed")]
        public new bool IsPhoneNumberConfirmed { get; set; }
        [Column("security_stamp")]
        public new string SecurityStamp { get; set; }
        [Column("is_two_factor_enabled")]
        public new bool IsTwoFactorEnabled { get; set; }
        [Column("is_email_confirmed")]
        public new bool IsEmailConfirmed { get; set; }
        [Column("is_active")]
        public new bool IsActive { get; set; }
        [Column("normalized_user_name")]
        public new string NormalizedUserName { get; set; }
        [Column("normalized_email_address")]
        public new string NormalizedEmailAddress { get; set; }
        [Column("concurrency_stamp")]
        public new string ConcurrencyStamp { get; set; }
        [Column("create_time")]
        public new DateTime CreationTime { get; set; }
        [Column("modified_time")]
        public new DateTime? LastModificationTime { get; set; }


        #endregion
    }
}