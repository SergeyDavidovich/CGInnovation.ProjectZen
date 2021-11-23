using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

//BusinessException is a special exception type.It is a good practice to throw domain related exceptions when needed.
//It is automatically handled by the ABP Framework and can be easily localized.WithData(...) method is used to provide
//additional data to the exception object that will later be used on the localization message or for some other purpose.

namespace CGInnovation.ProjectZen.Strategies
{
    public class StrategyAlreadyExistsException : BusinessException
    {
        public StrategyAlreadyExistsException(string name)
            : base(ProjectZenDomainErrorCodes.ProjectAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
