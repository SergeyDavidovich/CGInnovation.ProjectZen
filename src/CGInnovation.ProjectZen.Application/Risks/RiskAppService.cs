using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CGInnovation.ProjectZen.Risks
{
    public class RiskAppService: CrudAppService<
        Risk,
        RiskDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateRiskDto>, IRiskAppService
    {
        public RiskAppService(IRepository<Risk, Guid> repository)
            : base(repository)
        {

        }
    }
}
