namespace UMS.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using UMS.Infrastructure.DTOs;
    public class UMSDbContext : IdentityDbContext<User, Role, int>
    {
        public UMSDbContext(DbContextOptions<UMSDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            UMSDbContextConfigurations.Configure(builder);
        }
    }
}
