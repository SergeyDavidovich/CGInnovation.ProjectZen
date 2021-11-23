using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen.Strategies
{
    public interface IStrategyRepository : IRepository<Strategy, Guid>
    {
        Task<Strategy> FindByNameAsync(string name);
        Task<List<Strategy>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );
    }
}
