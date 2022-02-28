using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.RisksProjects;
using CGInnovation.ProjectZen.Strategies;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace CGInnovation.ProjectZen.RisksProjects
{
    /// <summary>
    /// This interface reflects Use Cases of Presentation Layer
    /// </summary>
    public interface IRiskProjectAppService : IApplicationService
    {
        #region Strategy Use Cases
        Task<List<StrategyDto>> GetSrategiesListAsync();
        Task<Guid> GetSelectedStrategyIdAsync(StrategyDto strategy);
        #endregion

        #region Project Use Cases 
        Task<List<ProjectDto>> GetProjectsListByStrategyIdAsync(Guid id);
        Task<Guid> GetSelectedProjectIdAsync(ProjectDto project);
        #endregion

        #region RiskProject Use Case
        Task<List<RiskProjectDto>> GetRisksInProjectListByProjectIdAsync(Guid id);
        Task<RiskProjectDto> GetSelectedRiskProjectAsync();
        Task<RiskProjectDto> EditRiskProject(RiskProjectDto riskProject);
        void CreateRiskProjectAsync(RiskProjectDto riskProject);
        void SaveRiskProjectAsync(RiskProjectDto riskProject);

        #endregion
    }
}

/*
Use Cases
================================
Get list of strategies
Select strategy

Get list of Projects by StrategyId
Select Project 

Assign Risk to Project 

Edit RiskProject 
Save RiskProject 

Get list of Risks
Select RiskProject by ProjectId
Create RiskProject
Select RiskProject
View Bubble diagram
Select Risk

 */