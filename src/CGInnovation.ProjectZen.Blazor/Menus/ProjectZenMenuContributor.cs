using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CGInnovation.ProjectZen.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using CGInnovation.ProjectZen.Permissions;

namespace CGInnovation.ProjectZen.Blazor.Menus
{
    public class ProjectZenMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public ProjectZenMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<ProjectZenResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    ProjectZenMenus.Home,
                    l["Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );
            context.Menu.Items.Insert(
                1,
                new ApplicationMenuItem(
                    ProjectZenMenus.Risk,
                    l["Risks"],
                    "/risks",
                    icon: "fa fa-book")
            );

            //if (await context.IsGrantedAsync(ProjectZenPermissions.Projects.Default))
            //{
            context.Menu.Items.Insert(
                2,
                new ApplicationMenuItem(
                ProjectZenMenus.Project,
                l["Projects"],
                url: "/projects",
                icon: "fa fa-book")
                );
            //}
            return Task.CompletedTask;

        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var accountStringLocalizer = context.GetLocalizer<AccountResource>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Manage",
                accountStringLocalizer["MyAccount"],
                $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
                icon: "fa fa-cog",
                order: 1000,
                null).RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}
