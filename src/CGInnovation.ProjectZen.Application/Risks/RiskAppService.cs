using CGInnovation.ProjectZen.Permissions;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(ProjectZenPermissions.Risks.Default)]

    public class RiskAppService: CrudAppService<
        Risk, //The Risk entity
        RiskDto, //Used to show risks
        Guid, //Primary key of the Risk entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateRiskDto>, //Used to create/update a risk
        IRiskAppService
    {
        public RiskAppService(IRepository<Risk, Guid> repository)
            : base(repository)
        {
            GetPolicyName = ProjectZenPermissions.Risks.Default;
            GetListPolicyName = ProjectZenPermissions.Risks.Default;
            CreatePolicyName = ProjectZenPermissions.Risks.Create;
            UpdatePolicyName = ProjectZenPermissions.Risks.Edit;
            DeletePolicyName = ProjectZenPermissions.Risks.Delete;
        }
    }
}
