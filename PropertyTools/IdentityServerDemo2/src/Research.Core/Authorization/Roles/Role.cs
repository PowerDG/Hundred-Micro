using Abp.Authorization.Roles;
using Research.Authorization.Users;

namespace Research.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        //Can add application specific role properties here

        public const int MaxDescriptionLength = 5000;
        public Role()
        {

        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }
    }
}