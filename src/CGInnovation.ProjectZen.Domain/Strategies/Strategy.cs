using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? TenantId { get; private set; }

        internal Strategy(Guid Id, [NotNull] string name, string description) 
            : base(Id)
        {
            SetName(name);
            Description = description;
        }
        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: StrategyConsts.MaxNameLength
                );
        }
        internal Strategy ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
    }
}
