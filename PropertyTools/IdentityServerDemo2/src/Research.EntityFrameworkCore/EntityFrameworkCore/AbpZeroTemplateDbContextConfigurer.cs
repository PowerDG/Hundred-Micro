using Microsoft.EntityFrameworkCore;

namespace Research.EntityFrameworkCore
{
    public static class ResearchDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ResearchDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }
    }

}