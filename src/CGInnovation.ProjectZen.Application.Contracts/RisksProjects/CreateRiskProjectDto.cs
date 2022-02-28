using CGInnovation.ProjectZen.Risks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class CreateRiskProjectDto
    {
        [Required]
        public Guid RiskId { get; private set; }
        [Required]
        public Guid ProjectId { get; private set; }
        [Required]
        public Guid? TenantId { get; private set; }
        [Required]
        public Mitigation Mitigation { get; set; }
        public Impact Impact { get; set; } 
        public Likelihood Likelihood { get; set; } 
        public DateTime OccuredDate { get; set; } 
    }
}
