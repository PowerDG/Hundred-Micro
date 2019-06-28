using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Fooww.Research.EntityFrameworkCore
{
    [ConnectionStringName("Research")]
    public class ResearchDbContext : AbpDbContext<ResearchDbContext>, IResearchDbContext
    {
        public static string TablePrefix { get; set; } = ResearchConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = ResearchConsts.DefaultDbSchema;

        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ResearchDbContext(DbContextOptions<ResearchDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureResearch(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}