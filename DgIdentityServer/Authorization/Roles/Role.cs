using Abp.Authorization.Roles;
using Research.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Research.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        //Can add application specific role properties here

        public Role()
        {

        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
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
        [Column("tenant_id")]
        public new int? TenantId { get; set; }
        [Column("name")]
        public new string Name { get; set; }
        [Column("display_name")]
        public new string DisplayName { get; set; }
        [Column("is_static")]
        public new bool IsStatic { get; set; }
        [Column("is_default")]
        public new bool IsDefault { get; set; }
        [Column("normalized_name")]
        public new string NormalizedName { get; set; }
        [Column("concurrency_stamp")]
        public new string ConcurrencyStamp { get; set; }
        [Column("description")]
        public string Description { get; set; }
        #endregion
    }
}