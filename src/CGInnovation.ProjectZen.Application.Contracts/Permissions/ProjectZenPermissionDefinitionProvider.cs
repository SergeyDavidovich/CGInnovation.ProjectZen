using CGInnovation.ProjectZen.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CGInnovation.ProjectZen.Permissions
{
    public class ProjectZenPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var riskStoreGroup = context.AddGroup(ProjectZenPermissions.GroupName, L("Risk store Management"));

            var riskPermission = riskStoreGroup.AddPermission(ProjectZenPermissions.Risks.Default, L("Permission:Risks"));
            riskPermission.AddChild(ProjectZenPermissions.Risks.Create, L("Permission:Risks.Create"));
            riskPermission.AddChild(ProjectZenPermissions.Risks.Edit, L("Permission:Risks.Edit"));
            riskPermission.AddChild(ProjectZenPermissions.Risks.Delete, L("Permission:Risks.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectZenResource>(name);
        }
    }
}
