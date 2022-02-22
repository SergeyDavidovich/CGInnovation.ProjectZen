using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.RisksInProjects;
using CGInnovation.ProjectZen.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class RisksProjectAppService : ProjectZenAppService, IRisksProjectAppService
    {
        public void CreateRiskProjectAsync(RiskProjectDto riskProject)
        {
            throw new NotImplementedException();
        }

        public Task<RiskProjectDto> EditRiskProject(RiskProjectDto riskProject)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectDto>> GetProjectsListByStrategyIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RiskProjectDto>> GetRisksInProjectListByProjectIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> GetSelectedProjectIdAsync(ProjectDto project)
        {
            throw new NotImplementedException();
        }

        public Task<RiskProjectDto> GetSelectedRiskProjectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> GetSelectedStrategyIdAsync(StrategyDto strategy)
        {
            throw new NotImplementedException();
        }

        public Task<List<StrategyDto>> GetSrategiesListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StrategyDto> GetStrategyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveRiskProjectAsync(RiskProjectDto riskProject)
        {
            throw new NotImplementedException();
        }
    }
}
