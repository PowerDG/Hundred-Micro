using System.Threading.Tasks;

namespace Fooww.Research.Data
{
    public interface IResearchDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
