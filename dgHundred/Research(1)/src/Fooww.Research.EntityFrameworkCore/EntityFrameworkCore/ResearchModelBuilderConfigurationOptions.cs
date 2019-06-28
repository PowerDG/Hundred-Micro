using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Fooww.Research.EntityFrameworkCore
{
    public class ResearchModelBuilderConfigurationOptions : ModelBuilderConfigurationOptions
    {
        public ResearchModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = ResearchConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = ResearchConsts.DefaultDbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}