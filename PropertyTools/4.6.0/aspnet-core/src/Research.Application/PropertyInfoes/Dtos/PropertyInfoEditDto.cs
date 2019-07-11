
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Research.PropertyInfoes;

namespace  Research.PropertyInfoes.Dtos
{
    public class PropertyInfoEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// PropertyFullName
		/// </summary>
		public string PropertyFullName { get; set; }



		/// <summary>
		/// Scope
		/// </summary>
		public string Scope { get; set; }



		/// <summary>
		/// PropertyType
		/// </summary>
		public string PropertyType { get; set; }



		/// <summary>
		/// PropertyName
		/// </summary>
		public string PropertyName { get; set; }



		/// <summary>
		/// Constructor
		/// </summary>
		public string Constructor { get; set; }



		/// <summary>
		/// DomainID
		/// </summary>
		public uint DomainID { get; set; }



		/// <summary>
		/// DomainName
		/// </summary>
		public string DomainName { get; set; }



		/// <summary>
		/// ColumnName
		/// </summary>
		public string ColumnName { get; set; }



		/// <summary>
		/// ColumnFullName
		/// </summary>
		public string ColumnFullName { get; set; }



		/// <summary>
		/// OrdinalPostion
		/// </summary>
		public uint? OrdinalPostion { get; set; }



		/// <summary>
		/// PropertyNameWithColumn
		/// </summary>
		public string PropertyNameWithColumn { get; set; }



		/// <summary>
		/// IsZeroModule
		/// </summary>
		public byte? IsZeroModule { get; set; }



		/// <summary>
		/// IsReNew
		/// </summary>
		public byte? IsReNew { get; set; }



		/// <summary>
		/// Id
		/// </summary> 




    }
}