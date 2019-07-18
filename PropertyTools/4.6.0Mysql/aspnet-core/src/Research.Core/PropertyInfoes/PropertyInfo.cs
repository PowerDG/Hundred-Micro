
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Abp.Domain.Entities;

namespace Research.PropertyInfoes
{
    public class PropertyInfo : Entity <int>
    { 

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int? Id { get; set; }
        public string PropertyFullName { get; set; } 
        public string PropertyNameWithColumn { get; set; }
        public string DomainName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnFullName { get; set; }

        public string PropertyType { get; set; }
        public string PropertyName { get; set; }

        public string Scope { get; set; }


        public uint? OrdinalPostion { get; set; }
        public string Constructor { get; set; }


        public byte? IsZeroModule { get; set; }
        public uint? DomainID { get; set; }
        public byte? IsReNew { get; set; }



        #region Auditing

        [Column("is_active")]
        public bool IsActive { get; set; }

        #region 创建
        [Column("creator_user_id")]
        public long? CreatorUserId { get; set; }

        [Column("create_time")]
        public DateTime CreationTime { get; set; }

        #endregion
        #region 修改
        [Column("last_modifier_user_id")]
        public long? LastModifierUserId { get; set; }

        [Column("modified_time")]
        public DateTime? LastModificationTime { get; set; }
        #endregion

        #region 删除 
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [Column("deleter_user_id")]
        public long? DeleterUserId { get; set; }

        [Column("deleted_time")]
        public DateTime? DeletionTime { get; set; }

        #endregion 

        #endregion Auditing
    }
}
