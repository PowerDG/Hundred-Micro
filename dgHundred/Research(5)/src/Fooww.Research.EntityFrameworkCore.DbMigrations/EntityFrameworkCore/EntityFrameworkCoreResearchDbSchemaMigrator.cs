using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fooww.Research.Data;
using Volo.Abp.DependencyInjection;

namespace Fooww.Research.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreResearchDbSchemaMigrator 
        : IResearchDbSchemaMigrator, ITransientDependency
    {
        private readonly ResearchMigrationsDbContext _dbContext;

        public EntityFrameworkCoreResearchDbSchemaMigrator(ResearchMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}