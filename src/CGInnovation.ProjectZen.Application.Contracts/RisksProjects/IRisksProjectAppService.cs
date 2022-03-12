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
        //#region Strategy Use Cases
        //#region Output
        //Task<List<GetStrategyListDto>> GetSrategiesListAsync();
        //Task<Guid> GetSelectedStrategyIdAsync(StrategyDto strategy);
        //#endregion
        //#endregion

        //#region Project Use Cases 
        //#region Output
        //Task<List<ProjectDto>> GetProjectsListByStrategyIdAsync(Guid id);
        //Task<Guid> GetSelectedProjectIdAsync(ProjectDto project);
        //#endregion
        //#endregion

        #region RiskProject Use Case

        #region Output
        Task<List<RiskProjectDto>> GetRisksInProjectListByProjectIdAsync(Guid id);
        Task<RiskProjectDto> GetSelectedRiskProjectAsync();
        #endregion

        #region Input
        void CreateRiskProjectAsync(CreateRiskProjectDto riskProject);
        Task<RiskProjectDto> EditRiskProject(UpdateRiskProjectDto riskProject);
        void SaveRiskProjectAsync(RiskProjectDto riskProject);
        #endregion

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