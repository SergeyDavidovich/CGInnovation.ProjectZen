using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using CGInnovation.ProjectZen.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CGInnovation.ProjectZen.Projects
{
    public class EfCoreProjectRepository : EfCoreRepository<ProjectZenDbContext, Project, Guid>,
            IProjectRepository
    {
        public EfCoreProjectRepository(IDbContextProvider<ProjectZenDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<Project> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(author => author.Name == name);
        }

        public async Task<List<Project>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    project => project.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
