using CGInnovation.ProjectZen.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CGInnovation.ProjectZen.Permissions
{
    public class ProjectZenPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProjectZenPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(ProjectZenPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectZenResource>(name);
        }
    }
}
