using System.Threading.Tasks;

namespace CGInnovation.ProjectZen.Data
{
    public interface IProjectZenDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
