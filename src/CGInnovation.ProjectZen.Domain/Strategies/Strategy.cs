using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities.Auditing;

namespace CGInnovation.ProjectZen.Strategies
{
    
    public class Strategy : AuditedAggregateRoot<Guid>// Type of the primary key of the Strategy
    {
        public Guid StrategyId { get; set; }

        public string Name { get; set; }
        
    }
}
