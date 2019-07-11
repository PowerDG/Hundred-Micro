

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using Research;
using Research.PropertyInfoes;


namespace Research.PropertyInfoes.DomainService
{
    /// <summary>
    /// PropertyInfo领域层的业务管理
    ///</summary>
    public class PropertyInfoManager :ResearchDomainServiceBase, IPropertyInfoManager
    {
		
		private readonly IRepository<PropertyInfo,int> _repository;

		/// <summary>
		/// PropertyInfo的构造方法
		///</summary>
		public PropertyInfoManager(
			IRepository<PropertyInfo, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitPropertyInfo()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
