using Fooww.Research.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Fooww.Research.Permissions
{
    public class ResearchPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ResearchPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ResearchPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ResearchResource>(name);
        }
    }
}
