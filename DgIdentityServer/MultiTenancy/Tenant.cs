using Abp.MultiTenancy;
using Research.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Research.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }

        #region MyRegion
        [Column("id")]
        public new int Id { get; set; }
        [Column("create_time")]
        public new DateTime CreationTime { get; set; }
        [Column("creator_user_id")]
        public new long? CreatorUserId { get; set; }
        [Column("modified_time")]
        public new DateTime? LastModificationTime { get; set; }
        [Column("last_modifier_user_id")]
        public new long? LastModifierUserId { get; set; }
        [Column("is_deleted")]
        public new bool IsDeleted { get; set; }
        [Column("deleter_user_id")]
        public new long? DeleterUserId { get; set; }
        [Column("deleted_time")]
        public new DateTime? DeletionTime { get; set; }
        [Column("tenancy_name")]
        public new string TenancyName { get; set; }
        [Column("name")]
        public new string Name { get; set; }
        [Column("connection_string")]
        public new string ConnectionString { get; set; }
        [Column("is_active")]
        public new bool IsActive { get; set; }
        [Column("edition_id")]
        public new int? EditionId { get; set; }
        #endregion
    }
}