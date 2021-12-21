using JetBrains.Annotations;
using System;
using System.Collections.Generic;
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
        private Project()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        [NotNull] public string Name { get; set; }
        [NotNull] public string Description { get; set; }
        public Guid? TenantId { get; private set; }
        public Guid StrategyId { get; set; }

        internal Project(Guid id, [NotNull] string name,
            string description, [NotNull] Guid strategyId)
            : base(id)
        {
            SetName(name);
            SetDescription(description);
            SetStrategyId(strategyId);
        }
        private void SetName([NotNull] string name)
        {
            Name =
                Check.NotNullOrWhiteSpace(
                    name,
                    nameof(name),
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
    }
}
