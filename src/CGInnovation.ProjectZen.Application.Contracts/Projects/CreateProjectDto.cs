using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CGInnovation.ProjectZen.Projects
{
    public class CreateProjectDto
    {
        [Required]
        [StringLength(ProjectConsts.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(ProjectConsts.MaxDescriptionLength)]
        public string Description { get; set; }

    }
}
