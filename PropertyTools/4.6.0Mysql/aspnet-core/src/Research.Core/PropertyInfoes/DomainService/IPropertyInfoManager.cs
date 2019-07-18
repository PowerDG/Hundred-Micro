

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Research.PropertyInfoes;


namespace Research.PropertyInfoes.DomainService
{
    public interface IPropertyInfoManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitPropertyInfo();



		 
      
         

    }
}
