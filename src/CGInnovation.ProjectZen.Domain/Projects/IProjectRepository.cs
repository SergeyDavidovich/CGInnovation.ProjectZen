using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen.Projects
{
    public interface IProjectRepository : IRepository<Project, Guid>
    {
        Task<Project> FindByNameAsync(string name);

        Task<List<Project>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
