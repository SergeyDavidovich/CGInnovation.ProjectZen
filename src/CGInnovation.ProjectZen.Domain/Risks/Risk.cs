using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Volo.Abp.MultiTenancy;

using Volo.Abp.Domain.Entities.Auditing;

namespace CGInnovation.ProjectZen.Risks
{
    public class Risk : AuditedAggregateRoot<Guid>, IMultiTenant // Type of the primary key of the Risk
    {
        public string Name { get; set; }
        public bool Occures { get; set; }
        public DateTime OccuredDate { get; set; }
        public Mitigation Mitigation { get; set; }
        public string MitigationDescription { get; set; }
        public Impact Impact { get; set; }
        public Likelihood Likelihood { get; set; }
        public Guid? TenantId { get; private set; }

        public Risk()
        {
            //This parameterless constructor is needed for ORMs
        }

        public Risk(
            string name,
            bool occures,
            DateTime occuredDate,
            Mitigation mitigation,
            string mitigationDescription,
            Guid? tenantId)
        {
            Name = name;
            Occures = occures;
            OccuredDate = occuredDate;
            Mitigation = mitigation;
            MitigationDescription = mitigationDescription;
            TenantId = tenantId; //Set in the constructor
        }

        //public DateTime CtreateDate { get; set; }
        //public DateTime UpdateDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
    }
}

//- Risk Scoring

// Likelihood(1 - 10, 10 highest)
// Impact(1 - 10, 10 highest)

//- Risk Data - properties not implemented because they inherit from class AuditedAggregateRoot<TKey>

// Created Date
// Updated Date
// Created By
// Updated By

// -Custom propeties

//- Mitigation(Full, Partial, None)
//- Mitigation Description(Text)
//- Occurred(Yes / No)
//- Occurred Date