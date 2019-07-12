using Abp.Authorization;
using Research.Authorization.Roles;
using Research.Authorization.Users;
using Research.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;

namespace Research.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock) 
            :  base(options, signInManager, systemClock)
        {
        }
    }
}