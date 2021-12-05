using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace CGInnovation.ProjectZen.Strategies
{
    public class Strategy : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        private Strategy()
        {
        }
        internal Strategy(Guid Id, [NotNull] string name, string description)
            : base(Id)
        {
            SetName(name);
            SetDescription(description);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? TenantId { get; private set; }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: StrategyConsts.MaxNameLength
                );
        }
        private void SetDescription(string description)
        {
            Description = Check.NotNullOrEmpty(description, nameof(description),
                maxLength: StrategyConsts.MaxStrategyDescription);
        }
        internal Strategy ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
        internal Strategy ChangeDescription(string description)
        {
            SetDescription(description);
            return this;
        }
    }
}
