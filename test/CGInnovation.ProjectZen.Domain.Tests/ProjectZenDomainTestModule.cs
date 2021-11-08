using CGInnovation.ProjectZen.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CGInnovation.ProjectZen
{
    [DependsOn(
        typeof(ProjectZenEntityFrameworkCoreTestModule)
        )]
    public class ProjectZenDomainTestModule : AbpModule
    {

    }
}