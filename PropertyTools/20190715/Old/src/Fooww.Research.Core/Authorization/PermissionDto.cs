using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
namespace Fooww.Research.Authorization
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto : EntityDto<long>
    {
        public string Name { get; set; }

        public ILocalizableString Description { get; set; }
        public string DisplayName { get; set; }


    }
}
