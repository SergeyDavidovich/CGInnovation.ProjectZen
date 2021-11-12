using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CGInnovation.ProjectZen.Risks
{
    public class CreateUpdateRiskDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        
        [Required]
        public bool Occures { get; set; }

        [Required]
        public DateTime OccuredDate { get; set; }
        
        [Required]
        public Mitigation Mitigation { get; set; }
        
        [Required]
        public string MitigationDescription { get; set; }

        [Required]
        public Impact Impact { get; set; }

        [Required]
        public Likelihood Likelihood { get; set; }

        [Required]
        public Guid? TenantId { get; private set; }
    }
}

