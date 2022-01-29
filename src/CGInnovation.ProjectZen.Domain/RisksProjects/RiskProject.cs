using CGInnovation.ProjectZen.Risks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities.Auditing;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Auditing;
using CGInnovation.ProjectZen.Projects;
using System.ComponentModel.DataAnnotations;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class RiskProject : Entity, IMultiTenant
    {
        #region properties
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }
        public Guid RiskId { get; private set; }
        public Risk Risk { get; private set; }
        public Guid? TenantId { get; private set; }
        public Mitigation Mitigation { get; private set; } = Mitigation.None;
        public Impact Impact { get; set; } = Impact.Level1;
        public Likelihood Likelihood { get; set; } = Likelihood.Level1;
        public DateTime OccuredDate { get; set; } = DateTime.Now;
        #endregion
        private RiskProject()
        {
            //This parameterless constructor is needed for ORMs
        }
        internal RiskProject(
            //[NotNull] Risk risk,
            //[NotNull] Project project)
            [NotNull] Guid riskId,
            [NotNull] Guid projectId)

        {
            //Project = project;
            //Risk = risk;
            SetRiskId(riskId);
            SetProjectId(projectId);
        }

        #region Set methods
        private void SetRiskId([NotNull] Guid riskId)
        {
            RiskId = Check.NotNull(riskId, nameof(riskId));
        }
        private void SetProjectId([NotNull] Guid projectId)
        {
            ProjectId = Check.NotNull(projectId, nameof(projectId));
        }
        private void SetMitigation([NotNull] Mitigation mitigation)
        {
            Mitigation = Check.NotNull(mitigation, nameof(mitigation));
        }
        private void SetImpact([NotNull] Impact impact)
        {
            Impact = Check.NotNull(impact, nameof(impact));
        }
        private void SetLikelihood([NotNull] Likelihood likelihood)
        {
            Likelihood = Check.NotNull(likelihood, nameof(likelihood));
        }
        private void SetOccuredDate([NotNull] DateTime occuredDate)
        {
            OccuredDate = Check.NotNull(occuredDate, nameof(occuredDate));
        }
        #endregion

        #region Change methods
        internal RiskProject ChangeMitigation([NotNull] Mitigation mitigation)
        {
            SetMitigation(mitigation);
            return this;
        }
        internal RiskProject ChangeImpact([NotNull] Impact impact)
        {
            SetImpact(impact);
            return this;
        }
        internal RiskProject ChangeLikelihood([NotNull] Likelihood likelihood)
        {
            SetLikelihood(likelihood);
            return this;
        }
        #endregion

        public override object[] GetKeys()
        {
            return new object[] { RiskId, ProjectId };
        }
    }
}
//public bool Occures { get; set; }
