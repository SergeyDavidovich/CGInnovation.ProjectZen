using Volo.Abp.Modularity;

namespace CGInnovation.ProjectZen
{
    [DependsOn(
        typeof(ProjectZenApplicationModule),
        typeof(ProjectZenDomainTestModule)
        )]
    public class ProjectZenApplicationTestModule : AbpModule
    {

    }
}