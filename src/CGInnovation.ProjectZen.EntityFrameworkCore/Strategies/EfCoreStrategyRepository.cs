using CGInnovation.ProjectZen.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CGInnovation.ProjectZen.Strategies
{
    public class EfCoreStrategyRepository 
        : EfCoreRepository<ProjectZenDbContext, Strategy, Guid>,
            IStrategyRepository
    {
        public EfCoreStrategyRepository(IDbContextProvider<ProjectZenDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        public async Task<Strategy> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(strategy => strategy.Name == name);
        }

        public async Task<List<Strategy>> GetListAsync(
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    strategy => strategy.Name.Contains(filter)
                 )
                //.OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
