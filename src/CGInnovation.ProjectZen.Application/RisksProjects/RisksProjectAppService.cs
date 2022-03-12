using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.RisksProjects;
using CGInnovation.ProjectZen.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class RisksProjectAppService : ProjectZenAppService, IRiskProjectAppService
    {
        private StrategyAppService _strategyAppService;
        private ProjectAppService _projectAppService;
        public RisksProjectAppService(
            StrategyAppService strategyAppService, 
            ProjectAppService projectAppService)
        {
            _strategyAppService = strategyAppService;
            _projectAppService = projectAppService;
        }

        #region Strategy Use Cases
        #region Output
        public async Task<PagedResultDto<StrategyDto>> 
            GetSrategiesListAsync(GetStrategyListDto input)
        {
            return await _strategyAppService.GetListAsync(input);
        }
        public Guid GetSelectedStrategyIdAsync(StrategyDto strategy)
        {
            return strategy.Id;
        }
        #endregion 
        #endregion

        #region Project Use Cases
        #region Output
        public Task<List<ProjectDto>> GetProjectsListByStrategyIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Guid> GetSelectedProjectIdAsync(ProjectDto project)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region RiskProject Use Case
        #region Output
        public Task<RiskProjectDto> GetSelectedRiskProjectAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<RiskProjectDto>> GetRisksInProjectListByProjectIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Input
        public Task<RiskProjectDto> EditRiskProject(UpdateRiskProjectDto riskProject)
        {
            throw new NotImplementedException();
        }
        public void CreateRiskProjectAsync(CreateRiskProjectDto riskProject)
        {
            throw new NotImplementedException();
        }
        public void SaveRiskProjectAsync(RiskProjectDto riskProject)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<StrategyDto>> GetListAsync(GetStrategyListDto input)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
