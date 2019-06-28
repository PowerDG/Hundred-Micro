using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Fooww.Research.MongoDB
{
    [ConnectionStringName("Research")]
    public interface IResearchMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
