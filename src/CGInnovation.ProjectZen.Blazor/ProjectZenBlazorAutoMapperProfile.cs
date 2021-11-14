using AutoMapper;
using CGInnovation.ProjectZen.Risks;

namespace CGInnovation.ProjectZen.Blazor
{
    public class ProjectZenBlazorAutoMapperProfile : Profile
    {
        public ProjectZenBlazorAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Blazor project.
            CreateMap<RiskDto, CreateUpdateRiskDto>();

        }
    }
}
