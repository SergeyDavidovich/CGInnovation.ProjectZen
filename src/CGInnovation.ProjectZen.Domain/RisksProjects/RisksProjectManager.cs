using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.Risks;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CGInnovation.ProjectZen.RisksProjects
{

    // 1. Creating RiskProject entity MUST bs assigned to Project
    internal class RisksProjectManager : DomainService
    {
        private IRiskProjectRepository _riskProjectRepository;
        private RiskProject _riskProject;
        public RisksProjectManager(IRiskProjectRepository riskProjectRepository)
        {
            _riskProjectRepository = riskProjectRepository;
        }
        public RiskProject Create
            (
            [NotNull] Guid riskId,
            [NotNull] Guid projectId
            )
        {
            _riskProject = new RiskProject(riskId, projectId);
            return _riskProject;
        }
        public void Change(
            [NotNull] RiskProject riskProject,
            [NotNull] Mitigation mitigation,
            [NotNull] Impact impact,
            [NotNull] Likelihood likelihood)
        {
            riskProject.ChangeMitigation(mitigation);
            riskProject.ChangeImpact(impact);
            riskProject.ChangeLikelihood(likelihood);
        }

        //Todo: I'm here
        //public async Task AssignAsync(Risk risk, Project project)
        //{
        //    //var issue = await _issueRepository.GetAsync(id);
        //    //var user = await _userRepository.GetAsync(userId);

        //    //await _issueManager.AssignAsync(issue, user);
        //    //await _issueRepository.UpdateAsync(issue);

        //    var assignedRisks = await _riskProjectRepository.GetRisksByProjectIdAsync(project.Id);


        //    if (assignedRisk != null && assignedRisk. != project.Id)
        //    {
        //        throw new ProjectAlreadyExistsException(newName);
        //    }
        //    var assignedRisk = new RiskProject(risk.Id, project.Id);

        //}
    }
}
