using Blazorise;
using Blazorise.DataGrid;
using CGInnovation.ProjectZen.Permissions;
using CGInnovation.ProjectZen.Strategies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.Blazor.Pages
{
    public partial class StrategiesPage
    {
        #region declarations
        private IReadOnlyList<StrategyDto> StrategyList { get; set; }
        private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
        private int CurrentPage { get; set; }
        private string CurrentSorting { get; set; }
        private int TotalCount { get; set; }

        private bool CanCreateStrategy { get; set; }
        private bool CanEditStrategy { get; set; }
        private bool CanDeleteStrategy { get; set; }
        private CreateStrategyDto NewStrategy { get; set; }

        private Guid EditingStrategyId { get; set; }
        private UpdateStrategyDto EditingStrategy { get; set; }

        private Modal CreateStrategyModal { get; set; }
        private Modal EditStrategyModal { get; set; }

        private Validations CreateValidationsRef;

        private Validations EditValidationsRef;
        #endregion
        public StrategiesPage()
        {
            NewStrategy = new CreateStrategyDto();
            EditingStrategy = new UpdateStrategyDto();
        }
        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await GetStrategiesAsync();
        }
        private async Task SetPermissionsAsync()
        {
            CanCreateStrategy = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.Strategies.Create);

            CanEditStrategy = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.Strategies.Edit);

            CanDeleteStrategy = await AuthorizationService
                .IsGrantedAsync(ProjectZenPermissions.Strategies.Delete);
        }

        private async Task GetStrategiesAsync()
        {
            var result = await StrategyAppService.GetListAsync(
                new GetStrategyListDto
                {
                    MaxResultCount = PageSize,
                    SkipCount = CurrentPage * PageSize,
                    Sorting = CurrentSorting
                }
            );

            StrategyList = result.Items;
            TotalCount = (int)result.TotalCount;
        }

        private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<StrategyDto> e)
        {
            CurrentSorting = e.Columns
                .Where(c => c.SortDirection != SortDirection.None)
                .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
                .JoinAsString(",");
            CurrentPage = e.Page - 1;

            await GetStrategiesAsync();

            await InvokeAsync(StateHasChanged);
        }
        private void OpenCreateStrategyModal()
        {
            CreateValidationsRef.ClearAll();

            NewStrategy = new CreateStrategyDto();
            CreateStrategyModal.Show();
        }

        private void CloseCreateStrategyModal()
        {
            CreateStrategyModal.Hide();
        }

        private void OpenEditStrategyModal(StrategyDto strategy)
        {
            EditValidationsRef.ClearAll();

            EditingStrategyId = strategy.Id;
            EditingStrategy = ObjectMapper.Map<StrategyDto, UpdateStrategyDto>(strategy);
            EditStrategyModal.Show();
        }
        private async Task DeleteStrategyAsync(StrategyDto strategy)
        {
            var confirmMessage = L["StrategyDeletionConfirmationMessage", strategy.Name];
            if (!await Message.Confirm(confirmMessage))
            {
                return;
            }

            await StrategyAppService.DeleteAsync(strategy.Id);
            await GetStrategiesAsync();
        }
        private void CloseEditStrategyModal()
        {
            EditStrategyModal.Hide();
        }

        private async Task CreateStrategyAsync()
        {
            if (CreateValidationsRef.ValidateAll())
            {
                await StrategyAppService.CreateAsync(NewStrategy);

                await GetStrategiesAsync();
                CreateStrategyModal.Hide();
            }
        }
        private async Task UpdateAuthorAsync()
        {
            if (EditValidationsRef.ValidateAll())
            {
                await StrategyAppService.UpdateAsync(EditingStrategyId, EditingStrategy);
                await GetStrategiesAsync();
                EditStrategyModal.Hide();
            }
        }
    }
}
