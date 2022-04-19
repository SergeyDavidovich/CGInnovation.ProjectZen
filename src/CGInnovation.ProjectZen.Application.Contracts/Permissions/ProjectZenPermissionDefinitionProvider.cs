using CGInnovation.ProjectZen.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

// https://docs.abp.io/en/abp/5.1/Authorization
namespace CGInnovation.ProjectZen.Permissions
{
    /// <summary>
    /// Defining Permissions
    /// </summary>
    public class ProjectZenPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var projectZenGroup = context.AddGroup(
                ProjectZenPermissions.GroupName, L("Permission:ProjectZen"));

            var riskPermission = projectZenGroup.AddPermission(
                ProjectZenPermissions.Risks.Default, L("Permission:Risks"));
            riskPermission.AddChild(
                ProjectZenPermissions.Risks.Create, L("Permission:Risks.Create"));
            riskPermission.AddChild(
                ProjectZenPermissions.Risks.Edit, L("Permission:Risks.Edit"));
            riskPermission.AddChild(
                ProjectZenPermissions.Risks.Delete, L("Permission:Risks.Delete"));

            var proectsPermission = projectZenGroup.AddPermission(
                ProjectZenPermissions.Projects.Default, L("Permission:Projects"));
            proectsPermission.AddChild(
                ProjectZenPermissions.Projects.Create, L("Permission:Projects.Create"));
            proectsPermission.AddChild(
                ProjectZenPermissions.Projects.Edit, L("Permission:Projects.Edit"));
            proectsPermission.AddChild(
                ProjectZenPermissions.Projects.Delete, L("Permission:Projects.Delete"));

            var strategysPermission = projectZenGroup.AddPermission(
                ProjectZenPermissions.Strategies.Default, L("Permission:Strategies"));
            strategysPermission.AddChild(
                ProjectZenPermissions.Strategies.Create, L("Permission:Strategies.Create"));
            strategysPermission.AddChild(
                ProjectZenPermissions.Strategies.Edit, L("Permission:Strategies.Edit"));
            strategysPermission.AddChild(
                ProjectZenPermissions.Strategies.Delete, L("Permission:Strategies.Delete"));

            var riskProjectPermission = projectZenGroup.AddPermission(
                ProjectZenPermissions.RisksProjects.Default, L("Permission:RiskProject"));
            riskProjectPermission.AddChild(
                ProjectZenPermissions.RisksProjects.Create, L("Permission:RiskProject.Create"));
            riskProjectPermission.AddChild(
                ProjectZenPermissions.RisksProjects.Delete, L("Permission:RiskProject.Delete"));
            riskProjectPermission.AddChild(
                ProjectZenPermissions.RisksProjects.Edit, L("Permission:RiskProject.Edit"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectZenResource>(name);
        }
    }
}
