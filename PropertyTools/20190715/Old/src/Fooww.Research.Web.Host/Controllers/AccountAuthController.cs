
using Fooww.Research.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

# region  构造注入using
using Abp.MultiTenancy;
using Fooww.Research.Authorization;
using Fooww.Research.Authentication.JwtBearer;
using Fooww.Research.Authentication.External;
using Fooww.Research.Authorization.Users;
#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Abp.Runtime.Security;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.UI;
using Fooww.Research.MultiTenancy; 
using Fooww.Research.Models.TokenAuth;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using AutoMapper;
using Abp.Domain.Repositories;
using Fooww.Research.Authorization.Roles;
using Fooww.Research.Roles.Dto;

namespace Fooww.Research.Web.Host.Controllers
{
    public class AccountAuthController : ResearchControllerBase
    {
        #region constructor 构造注入
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher; 
        private readonly IPermissionManager _permissionManager;

        private readonly LogInManager _logInManager;  
        private readonly ITenantCache _tenantCache;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly TokenAuthConfiguration _configuration;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        private readonly IExternalAuthManager _externalAuthManager;
        private readonly UserRegistrationManager _userRegistrationManager;

        public AccountAuthController(
            UserManager userManager,
            RoleManager roleManager, 
            IRepository<User, long> userRepository,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher, 
            IPermissionManager permissionManager,

            LogInManager logInManager,
            ITenantCache tenantCache,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            TokenAuthConfiguration configuration,
            IExternalAuthConfiguration externalAuthConfiguration,
            IExternalAuthManager externalAuthManager,
            UserRegistrationManager userRegistrationManager)
        { 
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _permissionManager = permissionManager;

            _logInManager = logInManager;
            _tenantCache = tenantCache;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _configuration = configuration;
            _externalAuthConfiguration = externalAuthConfiguration;
            _externalAuthManager = externalAuthManager;
            _userRegistrationManager = userRegistrationManager;
        }

        #endregion

        #region Account Authentication
        [HttpPost("api/AccountAuthenticate")]
        public async Task<JsonResult> AccountAuthenticate([FromBody] AuthenticateModel model)
        {

            SortedDictionary<string, object> DgDict = new SortedDictionary<string, object>();
            #region AccessTokenResult 
            var loginResult = await GetLoginResultAsync(
                model.UserNameOrEmailAddress,
                model.Password,
                GetTenancyNameOrNull()
            );
            var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
            var authenticateResultModel= new AuthenticateResultModel
            {
                AccessToken = accessToken,
                EncryptedAccessToken = GetEncrpyedAccessToken(accessToken),
                ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                UserId = loginResult.User.Id
            };
            DgDict.Add("authenticateResultModel", authenticateResultModel);
            #endregion

            return Json(DgDict);
        }

        [HttpPost("api/Authenticate")] 
        public async Task<AuthenticateResultModel> Authenticate([FromBody] AuthenticateModel model)
        {
            var loginResult = await GetLoginResultAsync(
                model.UserNameOrEmailAddress,
                model.Password,
                GetTenancyNameOrNull()
            ); 
            var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity)); 
            return new AuthenticateResultModel
            {
                AccessToken = accessToken,
                EncryptedAccessToken = GetEncrpyedAccessToken(accessToken),
                ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                UserId = loginResult.User.Id
            };
        }
        #endregion






        #region Dg权限集合与判断 Auth自定义方法

        [HttpPost("api/IsGrantedPermissionsAsync")]
        public virtual Task<bool> IsGrantedPermissionsAsync(string permissionName)
        { 
            return PermissionChecker.IsGrantedAsync(permissionName);
        }

        /// <summary>
        /// 获取当前用户权限集合
        /// </summary>
        /// <returns></returns>

        [HttpPost("api/GetGrantedCurrentPermissionsAsync")]
        public virtual async Task<List<PermissionDto>> GetGrantedCurrentPermissionsAsync()
        { 
            var userId = AbpSession.UserId.Value;
            var permissionList = new List<PermissionDto>(); 
            foreach (var permission in _permissionManager.GetAllPermissions())
            {
                if (await _userManager.IsGrantedAsync(userId, permission))
                { 
                    permissionList.Add(Mapper.Map<PermissionDto>(permission));
                }
            }
            return permissionList;
        }
        private   async Task<List<Permission>> GetGrantedCurrentPermissionAsync()
        {
            var userId = AbpSession.UserId.Value;
            var permissionList = new List<Permission>();
            foreach (var permission in _permissionManager.GetAllPermissions())
            {
                if (await _userManager.IsGrantedAsync(userId, permission))
                {
                    permissionList.Add(permission);
                }
            }
            return permissionList;
        }

        /// <summary>
        /// 获取指定用户权限集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// 
        [HttpPost("api/GetGrantedPermissionsAsync")]
        public virtual async Task<List<PermissionDto>> GetGrantedPermissionsAsync(long userId)
        {
            var permissionList = new List<PermissionDto>(); 
            foreach (var permission in _permissionManager.GetAllPermissions())
            {
                if (await _userManager.IsGrantedAsync(userId, permission))
                { 
                    permissionList.Add(Mapper.Map<PermissionDto>(permission));
                }
            }

            return permissionList; 
        }

        private  async Task<List<Permission>> GetGrantedPermissionAsync(long userId)
        {
            var permissionList = new List<Permission>(); 
            foreach (var permission in _permissionManager.GetAllPermissions())
            {
                if (await _userManager.IsGrantedAsync(userId, permission))
                { 
                    permissionList.Add(permission);
                }
            }

            return permissionList; 
        }
        


        #endregion

        #region 支持方法

        [HttpGet]
        public List<ExternalLoginProviderInfoModel> GetExternalAuthenticationProviders()
        {
            return ObjectMapper.Map<List<ExternalLoginProviderInfoModel>>(_externalAuthConfiguration.Providers);
        }



        [HttpPost]
        public async Task<ExternalAuthenticateResultModel> ExternalAuthenticate([FromBody] ExternalAuthenticateModel model)
        {
            var externalUser = await GetExternalUserInfo(model);

            var loginResult = await _logInManager.LoginAsync(new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider), GetTenancyNameOrNull());

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    {
                        var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
                        return new ExternalAuthenticateResultModel
                        {
                            AccessToken = accessToken,
                            EncryptedAccessToken = GetEncrpyedAccessToken(accessToken),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                        };
                    }
                case AbpLoginResultType.UnknownExternalLogin:
                    {
                        var newUser = await RegisterExternalUserAsync(externalUser);
                        if (!newUser.IsActive)
                        {
                            return new ExternalAuthenticateResultModel
                            {
                                WaitingForActivation = true
                            };
                        }

                        // Try to login again with newly registered user!
                        loginResult = await _logInManager.LoginAsync(new UserLoginInfo(model.AuthProvider, model.ProviderKey, model.AuthProvider), GetTenancyNameOrNull());
                        if (loginResult.Result != AbpLoginResultType.Success)
                        {
                            throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                                loginResult.Result,
                                model.ProviderKey,
                                GetTenancyNameOrNull()
                            );
                        }

                        return new ExternalAuthenticateResultModel
                        {
                            AccessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity)),
                            ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds
                        };
                    }
                default:
                    {
                        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                            loginResult.Result,
                            model.ProviderKey,
                            GetTenancyNameOrNull()
                        );
                    }
            }
        }

        private async Task<User> RegisterExternalUserAsync(ExternalAuthUserInfo externalUser)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                externalUser.Name,
                externalUser.Surname,
                externalUser.EmailAddress,
                externalUser.EmailAddress,
                Authorization.Users.User.CreateRandomPassword(),
                true
            );

            user.Logins = new List<UserLogin>
            {
                new UserLogin
                {
                    LoginProvider = externalUser.Provider,
                    ProviderKey = externalUser.ProviderKey,
                    TenantId = user.TenantId
                }
            };

            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }

        private async Task<ExternalAuthUserInfo> GetExternalUserInfo(ExternalAuthenticateModel model)
        {
            var userInfo = await _externalAuthManager.GetUserInfo(model.AuthProvider, model.ProviderAccessCode);
            if (userInfo.ProviderKey != model.ProviderKey)
            {
                throw new UserFriendlyException(L("CouldNotValidateExternalUser"));
            }

            return userInfo;
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _configuration.Expiration),
                signingCredentials: _configuration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        private string GetEncrpyedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, AppConsts.DefaultPassPhrase);
        }

        #endregion
    }
}
