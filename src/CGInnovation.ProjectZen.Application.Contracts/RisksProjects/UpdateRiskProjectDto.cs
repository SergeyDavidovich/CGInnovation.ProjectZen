using CGInnovation.ProjectZen.Risks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class UpdateRiskProjectDto
    {
        [Required]
        public Mitigation Mitigation { get; set; }
        [Required]
        public Impact Impact { get; set; } 
        [Required]
        public Likelihood Likelihood { get; set; }
    }
}
