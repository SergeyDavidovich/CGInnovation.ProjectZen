using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Domain.Entities.Auditing;

namespace CGInnovation.ProjectZen.Risks
{
    public class Risk : AuditedAggregateRoot<Guid> // Type of the primary key of the Risk
    {
        public Guid Id { get; set; }
        public DateTime CtreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Mitigation Mitigation { get; set; }
        public string MitigationDescription { get; set; }
        public bool Occures { get; set; }
        public DateTime OccuredDate { get; set; }
    }
}


//- Risk Scoring

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