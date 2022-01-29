using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public interface IRiskProjectRepository : IRepository<RiskProject>
    {
        /// <summary>
        /// returns all risks (RiskProject entity collection) 
        /// applied to any project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<List<RiskProject>> GetRisksByProjectIdAsync(Guid projectId);

      //  Task<List<RiskProject>> GetListAsync(
      //    int skipCount,
      //    int maxResultCount,
      //    string sorting,
      //    string filter = null
      //);
    }
}
 