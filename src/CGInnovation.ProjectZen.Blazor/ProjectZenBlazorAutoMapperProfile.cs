using AutoMapper;
using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.Risks;
using CGInnovation.ProjectZen.Strategies;

namespace CGInnovation.ProjectZen.Blazor
{
    public class ProjectZenBlazorAutoMapperProfile : Profile
    {
        public ProjectZenBlazorAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Blazor project.
            CreateMap<RiskDto, CreateUpdateRiskDto>();
            CreateMap<ProjectDto, UpdateProjectDto>();
            CreateMap<StrategyDto, UpdateStrategyDto>();
        }
    }
}
