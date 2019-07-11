using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Research.Authorization.Roles;
using Research.Authorization.Users;
using Research.MultiTenancy;
using Research.PropertyInfoes;

namespace Research.EntityFrameworkCore
{
    public class ResearchDbContext : AbpZeroDbContext<Tenant, Role, User, ResearchDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<PropertyInfo> PropertyInfos { get; set; }
        public DbSet<SchemaColumn> SchemaColumns { get; set; }
        public ResearchDbContext(DbContextOptions<ResearchDbContext> options)
            : base(options)
        {
        }
    }
}
