using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Fooww.Research.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fooww.Research.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserBriefDto : UserNameDto
    {
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string NormalizedUserName { get; set; }
    }

    [AutoMap(typeof(User))]
    public class UserNameDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}