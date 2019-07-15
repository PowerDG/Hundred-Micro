using Research.Configuration;
using Research.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Research.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ResearchDbContextFactory : IDesignTimeDbContextFactory<ResearchDbContext>
    {
        public ResearchDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ResearchDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            ResearchDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ResearchConsts.ConnectionStringName));

            return new ResearchDbContext(builder.Options);
        }
    }
}