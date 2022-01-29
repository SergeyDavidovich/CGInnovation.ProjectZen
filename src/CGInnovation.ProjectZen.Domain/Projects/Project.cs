using CGInnovation.ProjectZen.Risks;
using CGInnovation.ProjectZen.RisksProjects;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
namespace CGInnovation.ProjectZen.Projects
{
    public class Project : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        #region properties
        [NotNull] public string Name { get; set; }
        [NotNull] public string Description { get; set; }
        public Guid? TenantId { get; private set; }
        public Guid StrategyId { get; set; }
        public ICollection<Risk> Risks { get; set; }
        public ICollection<RiskProject> RisksOfProject { get; set; }
        #endregion
        private Project()
        {
            //This parameterless constructor is needed for ORMs
        }
        internal Project(
            Guid id, 
            [NotNull] string name,
            string description, 
            [NotNull] Guid strategyId)
            : base(id)
        {
            SetName(name);
            SetDescription(description);
            SetStrategyId(strategyId);
            RisksOfProject = new Collection<RiskProject>();
        }
        private void SetName([NotNull] string name)
        {
            Name =
                Check.NotNullOrWhiteSpace(name,nameof(name),
                    maxLength: ProjectConsts.MaxNameLength);
        }
        private void SetDescription([NotNull] string name)
        {
            Description =
                Check.NotNullOrWhiteSpace(name, nameof(name),
                maxLength: ProjectConsts.MaxDescriptionLength);
        }
        private void SetStrategyId([NotNull] Guid strategyId)
        {
            StrategyId =
                Check.NotNull(strategyId, nameof(strategyId));
        }

        internal Project ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
        internal Project ChangeDescription([NotNull] string description)
        {
            SetDescription(description);
            return this;
        }
        internal Project ChangeStrategyId([NotNull] Guid strategyId)
        {
            SetStrategyId(strategyId);
            return this;
        }

        private bool HasRisk(Guid riskId)
        {
            return Risks.Any(x => x.Id == riskId);
        }

        internal void AddRisk(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));

            if (HasRisk(riskId))
            {
                return;
            }

            RisksOfProject.Add(new RiskProject(riskId, this.Id));
        }
        internal void RemoveRisk(Guid riskId)
        {
            Check.NotNull(riskId, nameof(riskId));

            if (!HasRisk(riskId))
            {
                return;
            }

            RisksOfProject.RemoveAll(x => x.RiskId == riskId);
        }
        internal void RemoveAllRisks()
        {
            Risks.Clear();
        }
        internal void RemoveAllRisksExceptGivenIds(List<Guid> riskIds)
        {
            Check.NotNullOrEmpty(riskIds, nameof(riskIds));

            RisksOfProject.RemoveAll(x => !riskIds.Contains(x.RiskId));
        }
    }
}
