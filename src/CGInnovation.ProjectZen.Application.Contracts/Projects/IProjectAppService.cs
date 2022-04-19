using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CGInnovation.ProjectZen.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        #region output
        Task<ProjectDto> GetAsync(Guid id);
        Task<PagedResultDto<ProjectDto>> GetListAsync(GetProjectListDto input);
        Task<ListResultDto<StrategyLookupDto>> GetStrategyLookupAsync();
        #endregion

        #region input
        Task<ProjectDto> CreateAsync(CreateProjectDto input);
        Task UpdateAsync(Guid id, UpdateProjectDto input);
        Task DeleteAsync(Guid id);
        #endregion
    }
}
