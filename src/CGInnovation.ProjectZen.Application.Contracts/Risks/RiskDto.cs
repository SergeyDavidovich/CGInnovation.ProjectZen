using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.Risks
{
    public class RiskDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public bool Occures { get; set; }
        public DateTime OccuredDate { get; set; }
        public Mitigation Mitigation { get; set; }
        public string MitigationDescription { get; set; }
        public Impact Impact { get; set; }
        public Likelihood Likelihood { get; set; }
        public Guid? TenantId { get; private set; }

    }
}
