using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CGInnovation.ProjectZen.Data;
using Volo.Abp.DependencyInjection;

namespace CGInnovation.ProjectZen.EntityFrameworkCore
{
    public class EntityFrameworkCoreProjectZenDbSchemaMigrator
        : IProjectZenDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreProjectZenDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ProjectZenDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ProjectZenDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
