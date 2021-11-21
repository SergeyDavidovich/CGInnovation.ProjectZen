using CGInnovation.ProjectZen.Risks;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.RisksInProjects
{
    public class RisksInProjectsDto : EntityDto<Guid>
    {
        public Guid RiskId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? TenantId { get; set; }
        public Mitigation Mitigation { get; set; }
        public bool IsDeleted { get; set; }
    }
}
