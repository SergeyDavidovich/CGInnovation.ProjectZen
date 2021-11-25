using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CGInnovation.ProjectZen.Strategies
{
    public class StrategyDto :AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
