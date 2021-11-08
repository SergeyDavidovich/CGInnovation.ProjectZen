using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities.Auditing;

namespace CGInnovation.ProjectZen.Risks
{
    public class Risk : AuditedAggregateRoot<Guid>// Type of the primary key of the Risk
    {

    }
}


//-Risk Scoring
//- Likelihood(1 - 10, 10 highest)
//- Impact(1 - 10, 10 highest)
//- Risk Data
//- Created Date
//- Updated Date
//- Created By
//- Updated By
//- Mitigation(Full, Partial, None)
//- Mitigation Description(Text)
//- Occurred(Yes / No)
//- Occurred Date