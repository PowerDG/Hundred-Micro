using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Fooww.Research.MongoDB
{
    public class ResearchMongoModelBuilderConfigurationOptions : MongoModelBuilderConfigurationOptions
    {
        public ResearchMongoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = ResearchConsts.DefaultDbTablePrefix)
            : base(tablePrefix)
        {
        }
    }
}