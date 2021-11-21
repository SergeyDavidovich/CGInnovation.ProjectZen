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

namespace CGInnovation.ProjectZen.RisksInProjects
{
    public class RiskInProject : AuditedAggregateRoot<Guid>, IMultiTenant, ISoftDelete
    {
        public Guid RiskId { get; private set; }
        public Guid ProjectId { get; private set; }
        public Guid? TenantId { get; private set; }
        public Mitigation Mitigation { get; private set; }
        public bool IsDeleted { get; set; }

        private RiskInProject()
        {/* This constructor is for deserialization / ORM purpose */}
        internal RiskInProject(Guid id, [NotNull] Guid riskId, [NotNull] Guid projectId)
           : base(id)
        {
            SetRiskId(riskId);
            SetProjectId(projectId);
        }
        private void SetRiskId([NotNull] Guid riskId)
        {
            RiskId = Check.NotNull(riskId, nameof(riskId));
        }
        private void SetProjectId([NotNull] Guid projectId)
        {
            ProjectId = Check.NotNull(projectId, nameof(projectId));
        }
    }
}
