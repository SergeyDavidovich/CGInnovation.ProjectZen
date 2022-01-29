using CGInnovation.ProjectZen.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class EfRiskProjectRepository : 
        EfCoreRepository<ProjectZenDbContext, RiskProject>, IRiskProjectRepository
    {
        public EfRiskProjectRepository(IDbContextProvider<ProjectZenDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<RiskProject>> GetRisksByProjectIdAsync(
            Guid projectId)
        {
            var dbSet = await GetDbSetAsync();
            var result = await dbSet
                .Where(project => project.ProjectId==projectId)
                .ToListAsync();
            return result;
        }
    }
}
