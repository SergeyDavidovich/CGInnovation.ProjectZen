using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen.RisksInProjects
{
    public interface IRiskInProjectepository : IRepository<RiskInProject, Guid>
    {
        Task<RiskInProject> FindByNameAsync(string name);

        Task<List<RiskInProject>> GetListAsync(
           int skipCount,
           int maxResultCount,
           string sorting,
           string filter = null
       );
    }
}
