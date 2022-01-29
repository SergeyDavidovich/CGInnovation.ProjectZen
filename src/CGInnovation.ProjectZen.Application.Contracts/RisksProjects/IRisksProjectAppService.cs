using CGInnovation.ProjectZen.Strategies;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

// file:C:\GitHubMy\CGInnovation.ProjectZen\docs\ZenProject.eapx

namespace CGInnovation.ProjectZen.RisksProjects
{
    public interface IRisksProjectAppService : IApplicationService
    {
        Task<List<StrategyDto>> GetSrategiesListAsync();
        Task<StrategyDto> GetStrategyByIdAsync(Guid id);

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