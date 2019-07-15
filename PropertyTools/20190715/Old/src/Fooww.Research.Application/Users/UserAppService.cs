using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.Localization;
using Abp.Runtime.Security;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using Fooww.Research.Authorization;
using Fooww.Research.Authorization.Accounts;
using Fooww.Research.Authorization.Roles;
using Fooww.Research.Authorization.Users;
using Fooww.Research.Roles.Dto;
using Fooww.Research.Users.Dto;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fooww.Research.Users
{
    //    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAbpSession _abpSession;
        private readonly LogInManager _logInManager;

        private readonly IPermissionManager _permissionManager;

        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher,

            IPermissionManager permissionManager,
            IAbpSession abpSession,
            LogInManager logInManager)
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;

            _permissionManager = permissionManager;
            _abpSession = abpSession;
            _logInManager = logInManager;
        }

        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(user);
        }

        public override async Task<UserDto> Update(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.RoleNames));
            }

            return await Get(input);
        }

        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }

        protected override UserDto MapToEntityDto(User user)
        {
            var roles = _roleManager.Roles.Where(r => user.Roles.Any(ur => ur.RoleId == r.Id)).Select(r => r.NormalizedName);
            var userDto = base.MapToEntityDto(user);
            userDto.RoleNames = roles.ToArray();
            return userDto;
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedUserResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.EmailAddress.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

        public IEnumerable<UserBriefDto> GetAllUserBrief()
        {
            var userInfoes = (from users in Repository.GetAll()
                              where (users.IsActive == true)
                              select new UserBriefDto
                              {
                                  Id = users.Id,
                                  Name = users.Name,
                                  Surname = users.Surname,
                                  EmailAddress = users.EmailAddress,
                                  NormalizedUserName = users.NormalizedUserName
                              }).ToList();
            if (userInfoes == null)
            {
                throw new UserFriendlyException("UserInfoes is empty");
            }

            return userInfoes;
        }

        public Dictionary<long, string> GetAllUserName()
        {
            var userInfo = (from userDtos in Repository.GetAll()
                            where (userDtos.IsActive == true)
                            select new UserNameDto
                            {
                                Id = userDtos.Id,
                                Name = userDtos.Name
                            }).ToList();
            if (userInfo == null)
            {
                throw new UserFriendlyException("UserInfoes is empty");
            }

            Dictionary<long, string> users = new Dictionary<long, string>();
            foreach (UserNameDto user in userInfo)
            {
                users[user.Id] = user.Name;
            }

            return users;
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedUserResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<bool> ChangePassword(ChangePasswordDto input)
        {
            if (_abpSession.UserId == null)
            {
                throw new UserFriendlyException("Please log in before attemping to change password.");
            }
            long userId = _abpSession.UserId.Value;
            var user = await _userManager.GetUserByIdAsync(userId);
            var loginAsync = await _logInManager.LoginAsync(user.UserName, input.CurrentPassword, shouldLockout: false);
            if (loginAsync.Result != AbpLoginResultType.Success)
            {
                throw new UserFriendlyException("Your 'Existing Password' did not match the one on record.  Please try again or contact an administrator for assistance in resetting your password.");
            }
            if (!new Regex(AccountAppService.PasswordRegex).IsMatch(input.NewPassword))
            {
                throw new UserFriendlyException("Passwords must be at least 8 characters, contain a lowercase, uppercase, and number.");
            }
            user.Password = _passwordHasher.HashPassword(user, input.NewPassword);
            CurrentUnitOfWork.SaveChanges();
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto input)
        {
            if (_abpSession.UserId == null)
            {
                throw new UserFriendlyException("Please log in before attemping to reset password.");
            }
            long currentUserId = _abpSession.UserId.Value;
            var currentUser = await _userManager.GetUserByIdAsync(currentUserId);
            var loginAsync = await _logInManager.LoginAsync(currentUser.UserName, input.AdminPassword, shouldLockout: false);
            if (loginAsync.Result != AbpLoginResultType.Success)
            {
                throw new UserFriendlyException("Your 'Admin Password' did not match the one on record.  Please try again.");
            }
            if (currentUser.IsDeleted || !currentUser.IsActive)
            {
                return false;
            }
            var roles = await _userManager.GetRolesAsync(currentUser);
            if (!roles.Contains(StaticRoleNames.Tenants.Admin))
            {
                throw new UserFriendlyException("Only administrators may reset passwords.");
            }

            var user = await _userManager.GetUserByIdAsync(input.UserId);
            if (user != null)
            {
                user.Password = _passwordHasher.HashPassword(user, input.NewPassword);
                CurrentUnitOfWork.SaveChanges();
            }

            return true;
        }

        #region MyRegion

        public virtual Task<bool> GetGrantedPermissionsAsync(string permissionName)
        {
            //return PermissionChecker.IsGranted(UserIdentifier.Parse(AbpClaimTypes.UserId), permissionName);

            return PermissionChecker.IsGrantedAsync(permissionName);
        }

        public virtual async Task<bool> GetGranteddesignatedPermissionsAsync(long userId, string permissionName)
        {
            PermissionChecker.IsGranted(UserIdentifier.Parse(AbpClaimTypes.UserId), PermissionNames.Pages_Tenants);

            return await _userManager.IsGrantedAsync(userId, permissionName);
        }

        public virtual async Task<List<PermissionDto>> GetGrantedCurrentPermissionsAsync()
        {
            //var a=AbpClaimTypes.UserId;
            var userId = AbpSession.UserId.Value;
            var permissionList = new List<PermissionDto>();
            //var permissionDeatilList = new List<string>();
            foreach (var permission in _permissionManager.GetAllPermissions())
            {
                if (await _userManager.IsGrantedAsync(userId, permission))
                {
                    //permissionDeatilList.Add(permission.ToString());
                    permissionList.Add(Mapper.Map<PermissionDto>(permission));
                }
            }
            return permissionList;
        }

        public virtual async Task<List<PermissionDto>> GetGrantedAllPermissionsAsync(long userId)
        {
            var permissionList = new List<PermissionDto>();
            //var permissionDeatilList = new List<string>();
            foreach (var permission in _permissionManager.GetAllPermissions())
            {
                if (await _userManager.IsGrantedAsync(userId, permission))
                {
                    //permissionDeatilList.Add(permission.ToString());
                    permissionList.Add(Mapper.Map<PermissionDto>(permission));
                }
            }

            return permissionList;
            //.ToArray<Permission[]>();
            //https://www.cnblogs.com/dean-Wei/p/3150553.html
            //http://www.voidcn.com/article/p-wpdeckgc-btn.html
        }

        #endregion MyRegion
    }
}