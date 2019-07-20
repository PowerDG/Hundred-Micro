using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Research.Dtos
{
    internal class Class1
    {
        #region Auditing

        [Column("is_active")]
        public bool IsActive { get; set; }

        #region 创建

        [Column("creator_user_id")]
        public long? CreatorUserId { get; set; }

        [Column("create_time")]
        public DateTime CreationTime { get; set; }

        #endregion 创建

        #region 修改

        [Column("last_modifier_user_id")]
        public long? LastModifierUserId { get; set; }

        [Column("modified_time")]
        public DateTime? LastModificationTime { get; set; }

        #endregion 修改

        #region 删除

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("deleter_user_id")]
        public long? DeleterUserId { get; set; }

        [Column("deleted_time")]
        public DateTime? DeletionTime { get; set; }

        #endregion 删除

        #endregion Auditing
    }
}