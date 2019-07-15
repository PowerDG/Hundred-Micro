using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Fooww.Research.Authorization
{
    public class ResearchAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var Identifications = context.GetPermissionOrNull(PermissionNames.Identifications_Staff_Init);
            if (Identifications == null)
            {
                Identifications = context.CreatePermission(PermissionNames.Identifications_Staff_Init, L(PermissionNames.Identifications_Staff_Init));
            }

            Identifications.CreateChildPermission(PermissionNames.Identifications_Staff_Members, L(PermissionNames.Identifications_Staff_Members));
            Identifications.CreateChildPermission(PermissionNames.Identifications_Staff_Guest, L(PermissionNames.Identifications_Staff_Guest));
            Identifications.CreateChildPermission(PermissionNames.Identifications_Staff_Assistant, L(PermissionNames.Identifications_Staff_Assistant));

            var pages = context.GetPermissionOrNull(PermissionNames.Pages);

            if (pages == null)
                pages = context.CreatePermission(PermissionNames.Pages, L(PermissionNames.Pages));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ResearchConsts.LocalizationSourceName);
        }
    }
}