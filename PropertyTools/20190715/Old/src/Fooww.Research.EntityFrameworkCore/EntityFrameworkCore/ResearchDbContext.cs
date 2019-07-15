using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Fooww.Research.Authorization.Roles;
using Fooww.Research.Authorization.Users;
using Fooww.Research.MultiTenancy;

namespace Fooww.Research.EntityFrameworkCore
{
    public class ResearchDbContext : AbpZeroDbContext<Tenant, Role, User, ResearchDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ResearchDbContext(DbContextOptions<ResearchDbContext> options)
            : base(options)
        {
        }
    }
}
