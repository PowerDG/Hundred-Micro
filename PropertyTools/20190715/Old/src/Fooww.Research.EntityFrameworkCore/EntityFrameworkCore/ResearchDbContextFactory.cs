using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Fooww.Research.Configuration;
using Fooww.Research.Web;

namespace Fooww.Research.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ResearchDbContextFactory : IDesignTimeDbContextFactory<ResearchDbContext>
    {
        public ResearchDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ResearchDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ResearchDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ResearchConsts.ConnectionStringName));

            return new ResearchDbContext(builder.Options);
        }
    }
}
