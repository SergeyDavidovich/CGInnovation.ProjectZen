using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CGInnovation.ProjectZen.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ProjectZenDbContextFactory : IDesignTimeDbContextFactory<ProjectZenDbContext>
    {
        public ProjectZenDbContext CreateDbContext(string[] args)
        {
            ProjectZenEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ProjectZenDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ProjectZenDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CGInnovation.ProjectZen.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
