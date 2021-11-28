﻿using System;
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
        public bool Occures { get; set; }
        public DateTime OccuredDate { get; set; }
        public Mitigation Mitigation { get; set; }
        public string MitigationDescription { get; set; }

        public Guid? TenantId { get; private set; }
        public Guid ProjectId { get; set; }

        public Risk()
        {
            //This parameterless constructor is needed for ORMs
        }

        public Risk(
            bool occures,
            DateTime occuredDate,
            Mitigation mitigation,
            string mitigationDescription,
            Guid? tenantId)
        {
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

//- Likelihood(1 - 10, 10 highest)
//- Impact(1 - 10, 10 highest)

//- Risk Data

// Properties are inherits from AuditedAggregateRoot<TKey>
// https://docs.abp.io/en/abp/latest/Audit-Logging

// public virtual DateTime? LastModificationTime { get; set; }
// public virtual Guid? LastModifierId { get; set; }

// Custom propeties

//- Mitigation(Full, Partial, None)
//- Mitigation Description(Text)
//- Occurred(Yes / No)
//- Occurred Date