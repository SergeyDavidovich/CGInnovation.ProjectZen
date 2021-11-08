using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CGInnovation.ProjectZen.Data
{
    /* This is used if database provider does't define
     * IProjectZenDbSchemaMigrator implementation.
     */
    public class NullProjectZenDbSchemaMigrator : IProjectZenDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}