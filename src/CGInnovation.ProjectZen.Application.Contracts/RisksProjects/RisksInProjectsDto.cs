using CGInnovation.ProjectZen.Risks;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.RisksInProjects
{
    public class RiskProjectDto : AuditedEntityDto
    {
        public Guid RiskId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? TenantId { get; set; }
        public Mitigation Mitigation { get; set; }
        public string MitigationDescription { get; set; }
        public Impact Impact { get; set; }
        public Likelihood Likelihood { get; set; }
    }
}
