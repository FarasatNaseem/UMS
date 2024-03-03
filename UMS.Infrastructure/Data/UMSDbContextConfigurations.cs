namespace UMS.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using UMS.Infrastructure.DTOs;
    public class UMSDbContextConfigurations
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Configure custom entities
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");

            // Configure Identity entities
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(p => new { p.LoginProvider, p.ProviderKey });
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
        }
    }
}
