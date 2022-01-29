using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class RiskProjectAlreadyExistsExeption: BusinessException
    {
        public RiskProjectAlreadyExistsExeption(string name)
            :base(ProjectZenDomainErrorCodes.RiskProjectAlreadyExists)
        {
            WithData("name", name); 
        }
    }
}
