using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CGInnovation.ProjectZen.Strategies
{
    public interface IStrategyAppService : IApplicationService
    {
        Task<StrategyDto> GetAsync(Guid id);

        Task<PagedResultDto<StrategyDto>> GetListAsync(GetStrategyListDto input);

        Task<StrategyDto> CreateAsync(CreateStrategyDto input);

        Task UpdateAsync(Guid id, UpdateStrategyDto input);

        Task DeleteAsync(Guid id);
    }
}
