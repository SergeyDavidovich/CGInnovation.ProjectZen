using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace CGInnovation.ProjectZen.Projects
{
    public class ProjectAlreadyExistsException: BusinessException
    {
        public ProjectAlreadyExistsException(string name)
            : base(ProjectZenDomainErrorCodes.ProjectAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
