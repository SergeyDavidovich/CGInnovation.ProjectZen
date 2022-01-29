using CGInnovation.ProjectZen.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class RisksProjectAppService : ProjectZenAppService, IRisksProjectAppService
    {
        public Task<List<StrategyDto>> GetSrategiesListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StrategyDto> GetStrategyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
