using AutoMapper;
using CGInnovation.ProjectZen.Projects;
using CGInnovation.ProjectZen.Risks;

namespace CGInnovation.ProjectZen
{
    public class ProjectZenApplicationAutoMapperProfile : Profile
    {
        public ProjectZenApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Risk, RiskDto>();
            CreateMap<CreateUpdateRiskDto, Risk>();
            
            CreateMap<Project, ProjectDto>();
        }
    }
}
