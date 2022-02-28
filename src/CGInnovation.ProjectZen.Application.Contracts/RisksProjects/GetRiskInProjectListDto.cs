using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class GetRiskInProjectListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}
