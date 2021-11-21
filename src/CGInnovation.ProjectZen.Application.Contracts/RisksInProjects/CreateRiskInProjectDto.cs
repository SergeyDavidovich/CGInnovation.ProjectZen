using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CGInnovation.ProjectZen.RisksInProjects
{
    public class CreateRiskInProjectDto
    {
        [Required]
        public Guid RiskId { get; private set; }
        [Required]

        public Guid ProjectId { get; private set; }
        [Required]

        public Guid? TenantId { get; private set; }
        [Required]
        public Risks.Mitigation Mitigation { get; private set; }
    }
}
