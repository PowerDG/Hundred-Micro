using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Research.Authorization.Roles;
using Research.Authorization.Users;
using Research.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Research.EntityFrameworkCore
{
    public class ResearchDbContext : AbpZeroDbContext<Tenant, Role, User, ResearchDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */

        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public ResearchDbContext(DbContextOptions<ResearchDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
