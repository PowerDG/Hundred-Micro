using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Fooww.Research.EntityFrameworkCore
{
    [ConnectionStringName("Research")]
    public interface IResearchDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}