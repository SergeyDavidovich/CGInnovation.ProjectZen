using CGInnovation.ProjectZen.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CGInnovation.ProjectZen.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ProjectZenEntityFrameworkCoreModule),
        typeof(ProjectZenApplicationContractsModule)
        )]
    public class ProjectZenDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
