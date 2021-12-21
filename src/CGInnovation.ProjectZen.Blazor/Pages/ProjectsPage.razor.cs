using Blazorise;
using Blazorise.DataGrid;
using CGInnovation.ProjectZen.Permissions;
using CGInnovation.ProjectZen.Projects;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.Blazor.Pages
{
    public partial class ProjectsPage
    {
        #region declarations
        private IReadOnlyList<ProjectDto> ProjectList { get; set; }
        private IReadOnlyList<StrategyLookupDto> strategyList = Array.Empty<StrategyLookupDto>();
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; }
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }
        private bool CanCreateProject { get; set; }
        private bool CanEditProject { get; set; }
        private bool CanDeleteProject { get; set; }
        private CreateProjectDto NewProject { get; set; }

        private Guid EditingProjectId { get; set; }
        private UpdateProjectDto EditingProject { get; set; }

        private Modal CreateProjectModal { get; set; }
        private Modal EditProjectModal { get; set; }

        private Validations CreateValidationsRef;

        private Validations EditValidationsRef;
        #endregion
        public ProjectsPage()
        {
            NewProject = new CreateProjectDto();
            EditingProject = new UpdateProjectDto();
        }
        protected override async Task OnInitializedAsync()
        {
#if DEBUG
            await Task.Delay(0);
#endif

            await SetPermissionsAsync();
            await GetProjectsAsync();
            strategyList = (await ProjectAppService.GetStrategyLookupAsync()).Items;
        }
        private async Task SetPermissionsAsync()
        {
            CanCreateProject = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.Projects.Create);

            CanEditProject = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.Projects.Edit);

            CanDeleteProject = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.Projects.Delete);
        }

        private async Task GetProjectsAsync()
        {
            var result = await ProjectAppService.GetListAsync(
                new GetProjectListDto
                {
                    MaxResultCount = PageSize,
                    SkipCount = CurrentPage * PageSize,
                    Sorting = CurrentSorting
                }
            );

            ProjectList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<ProjectDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.None)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page - 1;

            await GetProjectsAsync();

            await InvokeAsync(StateHasChanged);
        }
        private void OpenCreateProjectModal()
        {
            CreateValidationsRef.ClearAll();

            NewProject = new CreateProjectDto();
            CreateProjectModal.Show();
        }

        private void CloseCreateProjectModal()
        {
            CreateProjectModal.Hide();
        }

        private void OpenEditProjectModal(ProjectDto project)
        {
            EditValidationsRef.ClearAll();

            EditingProjectId = project.Id;
            EditingProject = ObjectMapper.Map<ProjectDto, UpdateProjectDto>(project);
            EditProjectModal.Show();
        }
        private async Task DeleteProjectAsync(ProjectDto project)
        {
            var confirmMessage = L["ProjectDeletionConfirmationMessage", project.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await ProjectAppService.DeleteAsync(project.Id);
            await GetProjectsAsync();
        }
        private void CloseEditProjectModal()
        {
            EditProjectModal.Hide();
        }
        private async Task CreateProjectAsync()
        {
            if (CreateValidationsRef.ValidateAll())
            {
                await ProjectAppService.CreateAsync(NewProject);
                await GetProjectsAsync();
                CreateProjectModal.Hide();
            }
        }
        private async Task UpdateProjectAsync()
        {
            if (EditValidationsRef.ValidateAll())
            {
                await ProjectAppService.UpdateAsync(EditingProjectId, EditingProject);
                await GetProjectsAsync();
                EditProjectModal.Hide();
            }
        }
    }
}
