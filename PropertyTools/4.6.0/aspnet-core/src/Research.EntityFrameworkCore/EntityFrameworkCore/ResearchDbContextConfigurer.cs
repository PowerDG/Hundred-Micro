using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Research.EntityFrameworkCore
{
    public static class ResearchDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ResearchDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ResearchDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
