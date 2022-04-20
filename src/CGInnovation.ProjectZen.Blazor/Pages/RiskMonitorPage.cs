using CGInnovation.ProjectZen.Permissions;
using CGInnovation.ProjectZen.Projects;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CGInnovation.ProjectZen.Blazor.Pages
{
    public class MySelectModel
    {
        public Guid MyValueField { get; set; }
        public string MyTextField { get; set; }
    }

    public partial class RiskMonitorPage
    {
        #region Declarations
        private IReadOnlyList<StrategyLookupDto> StrategyList = Array.Empty<StrategyLookupDto>();
       private Guid selectedListValue { get; set; } 

        

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
            //await SetPermissionsAsync();
            StrategyList = (await ProjectAppService.GetStrategyLookupAsync()).Items;

            await base.OnInitializedAsync();
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
