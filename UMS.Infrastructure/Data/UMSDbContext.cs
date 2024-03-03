namespace UMS.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using UMS.Infrastructure.DTOs;

    /// <summary>
    /// Represents the Entity Framework DbContext for the UMS application, extending IdentityDbContext.
    /// </summary>
    public class UMSDbContext : IdentityDbContext<User, Role, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UMSDbContext"/> class.
        /// </summary>
        /// <param name="options">The DbContext options.</param>
        public UMSDbContext(DbContextOptions<UMSDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the model using the provided ModelBuilder.
        /// </summary>
        /// <param name="builder">The ModelBuilder instance used to configure the DbContext.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply custom configurations
            UMSDbContextConfigurations.Configure(builder);
        }
    }
}