using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.RisksProjects;
using CGInnovation.ProjectZen.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace CGInnovation.ProjectZen.RisksProjects
{
    public class RisksProjectAppService : ProjectZenAppService, IRiskProjectAppService
    {
        private ProjectAppService _projectAppService;
        private IRiskProjectRepository _riskProjectsRepository;
        public RisksProjectAppService(
            ProjectAppService projectAppService,
            IRiskProjectRepository  riskProjectsRepository)
                {
            _projectAppService = projectAppService;
            _riskProjectsRepository = riskProjectsRepository;
        }

        #region output
        public async Task<List<RiskProjectDto>> GetListAsync(Guid projectId)
        {
            var riskProjects = await _riskProjectsRepository.GetListAsync();

            var listRiskProjectsDto =
                new List<RiskProjectDto>(
                ObjectMapper.Map<List<RiskProject>,
                List<RiskProjectDto>>(riskProjects));
            return listRiskProjectsDto;
        }

        //public async Task<RiskProjectDto> GetAsync(Guid riskId, Guid projectId)
        //{
        //    var riskProject = await _riskProjectsRepository.GetAsync(riskId, projectId);
        //    return new RiskProjectDto();
        //}

        #endregion

        #region input

        public Task CreateAsync(CreateRiskProjectDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid riskId, Guid projectId)
        {
            throw new NotImplementedException();
        }
        public Task<RiskProjectDto> UpdateAsync(UpdateRiskProjectDto input)
        {
            throw new NotImplementedException();
        }

        public Task<RiskProjectDto> GetAsync(Guid riskId, Guid projectId)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
