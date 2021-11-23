using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.Strategies
{
    public class GetStrategyListDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
