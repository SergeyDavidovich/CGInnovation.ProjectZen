using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CGInnovation.ProjectZen.RisksInProjects
{
    internal class RisksInProjectManager : DomainService
    {
        private IRiskInProjectepository _riskInProjectepository;

        public RisksInProjectManager(IRiskInProjectepository riskInProjectepository)
        {
            _riskInProjectepository = riskInProjectepository;       
        }
        public async Task<RiskInProject> CreateAsync([NotNull] string name)
        {
            Check.NotNull(name, nameof(name));

            return new RiskInProject(
                GuidGenerator.Create(), GuidGenerator.Create(), GuidGenerator.Create());
        }
    }
}
