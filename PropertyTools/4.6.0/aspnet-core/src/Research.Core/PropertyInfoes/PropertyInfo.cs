
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

        public uint? OrdinalPostion { get; set; }
        public string ColumnName { get; set; }
        public string ColumnFullName { get; set; }

        public string PropertyNameWithColumn { get; set; } 
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }

        public string Scope { get; set; }

        public string Constructor { get; set; }


        public byte? IsZeroModule { get; set; }
        public uint? DomainID { get; set; }
        public byte? IsReNew { get; set; }
        public string DomainName { get; set; } 
    }
}
