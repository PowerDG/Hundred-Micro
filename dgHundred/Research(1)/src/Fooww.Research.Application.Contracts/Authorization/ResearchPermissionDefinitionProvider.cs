using Fooww.Research.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Fooww.Research.Authorization
{
    public class ResearchPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(ResearchPermissions.GroupName, L("Permission:Research"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ResearchResource>(name);
        }
    }
}