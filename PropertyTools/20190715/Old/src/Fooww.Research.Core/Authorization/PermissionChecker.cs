using Abp.Authorization;
using Fooww.Research.Authorization.Roles;
using Fooww.Research.Authorization.Users;

namespace Fooww.Research.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}