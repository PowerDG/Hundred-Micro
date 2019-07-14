
using System;
using System.Collections.Generic;
using System.Text;

using Abp.Runtime.Session; 
using System.Security.Claims;
using System.Linq;
using Abp.Configuration.Startup;

namespace Research.Extensions
{
    /// <summary>
    /// 通过扩展方法来对AbpSession进行扩展
    /// https://www.cnblogs.com/sheng-jie/p/6370338.html#autoid-2-0-0
    /// </summary>
    public static class AbpSessionExtension
    {
        public static string GetUserEmail(this IAbpSession session)
        {
            return GetClaimValue(ClaimTypes.Email);
        }

        private static string GetClaimValue(string claimType)
        {
            var claimsPrincipal = DefaultPrincipalAccessor.Instance.Principal;

            var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);
            if (string.IsNullOrEmpty(claim?.Value))
                return null;

            return claim.Value;
        }
    }
    //public interface IAbpSessionExtension : IAbpSession
    //{
    //    string Email { get; }
    //}

    //public class AbpSessionExtension : ClaimsAbpSession, IAbpSessionExtension
    //{
    //    public AbpSessionExtension(IMultiTenancyConfig multiTenancy)  : base(multiTenancy)
    //    {
    //    }

    //    public string Email => GetClaimValue(ClaimTypes.Email);

    //    private string GetClaimValue(string claimType)
    //    {
    //        var claimsPrincipal = PrincipalAccessor.Principal;

    //        var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);
    //        if (string.IsNullOrEmpty(claim?.Value))
    //            return null;

    //        return claim.Value;
    //    }



/// <summary>
/// 通过扩展方法来对AbpSession进行扩展
/// </summary>
public static class AbpSessionExtension2
{
    public static string GetUserEmail(this IAbpSession session)
    {
        return GetClaimValue(ClaimTypes.Email);
    }

    private static string GetClaimValue(string claimType)
    {
        var claimsPrincipal = DefaultPrincipalAccessor.Instance.Principal;

        var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);
        if (string.IsNullOrEmpty(claim?.Value))
            return null;

        return claim.Value;
    }
}
}