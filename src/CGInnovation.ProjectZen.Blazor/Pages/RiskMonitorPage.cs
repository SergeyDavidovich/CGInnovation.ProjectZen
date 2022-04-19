using CGInnovation.ProjectZen.Permissions;
using CGInnovation.ProjectZen.Projects;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CGInnovation.ProjectZen.Blazor.Pages
{
    public partial class RiskMonitorPage
    {
        #region Declarations
        private IReadOnlyList<StrategyLookupDto> StrategyList = Array.Empty<StrategyLookupDto>();


        private bool CanCreateRiskProject { get; set; }
        private bool CanEditRiskProject { get; set; }
        private bool CanDeleteRiskProject { get; set; }
        #endregion

        public RiskMonitorPage()
        {
        }
        protected override async Task OnInitializedAsync()
        {
#if DEBUG
            await Task.Delay(0);
#endif
            await SetPermissionsAsync();
            //await GetProjectsAsync();

            StrategyList = (await ProjectAppService.GetStrategyLookupAsync()).Items;
        }

        private async Task SetPermissionsAsync()
        {
            CanCreateRiskProject = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.RisksProjects.Create);

            CanEditRiskProject = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.RisksProjects.Edit);

            CanDeleteRiskProject = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.RisksProjects.Delete);
        }
    }
}
