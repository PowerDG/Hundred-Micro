
using System;
using System.Collections.Generic;
using System.Text;

using Abp.Domain.Entities;

namespace Research.PropertyInfoes
{
    public class SchemaColumn : Entity<uint>
    {

        public uint DomainID { get; set; }
        public string TABLE_SCHEMA { get; set; }
        public string TABLE_NAME { get; set; } 
        public uint ORDINAL_POSITION { get; set; }

        //public uint OrdinalPostion { get; set; }
        public string COLUMN_NAME { get; set; }

        public string COLUMN_TYPE { get; set; }
        public string DATA_TYPE { get; set; }
        //public string ColumnName { get; set; }

        //public string ColumnType { get; set; }
        //public string DataType { get; set; }

        public string ColumnFullName { get; set; }
    }
}
