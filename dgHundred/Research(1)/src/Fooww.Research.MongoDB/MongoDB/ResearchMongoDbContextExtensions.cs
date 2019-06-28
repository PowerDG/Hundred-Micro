using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Fooww.Research.MongoDB
{
    public static class ResearchMongoDbContextExtensions
    {
        public static void ConfigureResearch(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ResearchMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
        }
    }
}