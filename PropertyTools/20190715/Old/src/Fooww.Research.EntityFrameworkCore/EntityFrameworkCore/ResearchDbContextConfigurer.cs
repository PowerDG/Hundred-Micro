using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Fooww.Research.EntityFrameworkCore
{
    public static class ResearchDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ResearchDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ResearchDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}