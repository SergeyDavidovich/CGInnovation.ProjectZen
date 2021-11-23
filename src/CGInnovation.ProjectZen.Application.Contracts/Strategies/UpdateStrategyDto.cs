using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CGInnovation.ProjectZen.Strategies
{
    public class UpdateStrategyDto
    {
        [Required]
        [StringLength(StrategyConsts.MaxNameLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
