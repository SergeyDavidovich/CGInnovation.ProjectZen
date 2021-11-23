using CGInnovation.ProjectZen.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CGInnovation.ProjectZen.Permissions
{
    public class ProjectZenPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var projectZenGroup = context.AddGroup(ProjectZenPermissions.GroupName, L("Permission:ProjectZen"));

            var riskPermission = projectZenGroup.AddPermission(ProjectZenPermissions.Risks.Default, L("Permission:Risks"));
            riskPermission.AddChild(ProjectZenPermissions.Risks.Create, L("Permission:Risks.Create"));
            riskPermission.AddChild(ProjectZenPermissions.Risks.Edit, L("Permission:Risks.Edit"));
            riskPermission.AddChild(ProjectZenPermissions.Risks.Delete, L("Permission:Risks.Delete"));

            var proectsPermission = projectZenGroup.AddPermission(ProjectZenPermissions.Projects.Default, L("Permission:Proects"));
            proectsPermission.AddChild(ProjectZenPermissions.Projects.Create, L("Permission:Proects.Create"));
            proectsPermission.AddChild(ProjectZenPermissions.Projects.Edit, L("Permission:Proects.Edit"));
            proectsPermission.AddChild(ProjectZenPermissions.Projects.Delete, L("Permission:Proects.Delete"));

            var strategysPermission = projectZenGroup.AddPermission(ProjectZenPermissions.Strategies.Default, L("Permission:Strategies"));
            strategysPermission.AddChild(ProjectZenPermissions.Strategies.Create, L("Permission:Strategies.Create"));
            strategysPermission.AddChild(ProjectZenPermissions.Strategies.Edit, L("Permission:Strategies.Edit"));
            strategysPermission.AddChild(ProjectZenPermissions.Strategies.Delete, L("Permission:Strategies.Delete"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectZenResource>(name);
        }
    }
}
