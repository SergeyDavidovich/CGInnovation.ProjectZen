using CGInnovation.ProjectZen.Risks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities.Auditing;


namespace CGInnovation.ProjectZen.RisksInProjects
{
    public class RiskInProject : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid RiskId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime DateTime{get;set;}
        public Guid? TenantId{get;set;}
        public Mitigation Mitigation{get;set;}
    }
}
