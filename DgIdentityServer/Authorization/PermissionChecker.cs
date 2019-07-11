using Abp.Authorization;
using Research.Authorization.Roles;
using Research.Authorization.Users;

namespace Research.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
