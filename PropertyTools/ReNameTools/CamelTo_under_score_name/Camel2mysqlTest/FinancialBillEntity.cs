using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Camel2mysqlTest
{
    public class FinancialBillEntity
    {
        //[Display(Name = "类型")]
        //public BussinessType AdvertiseType { get; set; }


        [Display(Name = "平台2343")]
        public string AdvertisePlantform { get; set; }


        [Display(Name = "签约12312")]
        public string PlantformSignEntity { get; set; }
    }

    public enum AdvertiseType : Int32
    {
        /// <summary>
        /// Search
        /// </summary>
        [Display(Name = "Search")]
        Search = 1,

        /// <summary>
        /// Display
        /// </summary>
        [Display(Name = "Display")]
        Display = 2,
    }
}
