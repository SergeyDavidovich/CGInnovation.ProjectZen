using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities.Auditing;

namespace CGInnovation.ProjectZen.Projects
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        public string ProjectName { get; set; }
    }
}
