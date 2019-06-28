using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Fooww.Research.Data
{
    /* This is used if database provider does't define
     * IResearchDbSchemaMigrator implementation.
     */
    public class NullResearchDbSchemaMigrator : IResearchDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}