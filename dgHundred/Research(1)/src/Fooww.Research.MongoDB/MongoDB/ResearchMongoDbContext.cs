using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Fooww.Research.MongoDB
{
    [ConnectionStringName("Research")]
    public class ResearchMongoDbContext : AbpMongoDbContext, IResearchMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = ResearchConsts.DefaultDbTablePrefix;

        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureResearch(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}