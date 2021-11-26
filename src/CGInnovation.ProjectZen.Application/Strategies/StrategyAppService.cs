using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGInnovation.ProjectZen.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen.Strategies
{

    [Authorize(ProjectZenPermissions.Strategies.Default)]
    public class StrategyAppService : ProjectZenAppService, IStrategyAppService
    {
        private readonly IStrategyRepository _strategyRepository;
        private readonly StrategyManager _strategyManager;

        public StrategyAppService(
            IStrategyRepository strategyRepository,
            StrategyManager strategyManager)
        {
            _strategyRepository = strategyRepository;
            _strategyManager = strategyManager;
        }
        [Authorize(ProjectZenPermissions.Strategies.Create)]
        public async Task<StrategyDto> CreateAsync(CreateStrategyDto input)
        {
            var strategy = await _strategyManager.CreateAsync(input.Name, input.Description);

            await _strategyRepository.InsertAsync(strategy);

            var strategyDto = ObjectMapper.Map<Strategy, StrategyDto>(strategy);

            return strategyDto;
        }
        [Authorize(ProjectZenPermissions.Strategies.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _strategyRepository.DeleteAsync(id);
        }

        public async Task<StrategyDto> GetAsync(Guid id)
        {
            var strategy = await _strategyRepository.GetAsync(id);
            return ObjectMapper.Map<Strategy, StrategyDto>(strategy);
        }

        public async Task<PagedResultDto<StrategyDto>> GetListAsync(GetStrategyListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Strategy.Name);
            }

            var strategies = await _strategyRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _strategyRepository.CountAsync()
                : await _strategyRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<StrategyDto>(
                totalCount,
                ObjectMapper.Map<List<Strategy>, List<StrategyDto>>(strategies)
            );
        }
        [Authorize(ProjectZenPermissions.Strategies.Edit)]

        public async Task UpdateAsync(Guid id, UpdateStrategyDto input)
        {
            var strategy = await _strategyRepository.GetAsync(id);

            if (strategy.Name != input.Name)
            {
                await _strategyManager.ChangeNameAsync(strategy, input.Name);
            }
            await _strategyRepository.UpdateAsync(strategy);
        }
    }
}
