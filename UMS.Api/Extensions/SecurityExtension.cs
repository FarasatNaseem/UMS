namespace UMS.Api.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using UMS.Infrastructure.Data;
    using UMS.Infrastructure.DTOs;

    /// <summary>
    /// Extension methods for configuring and registering security-related services in the UMS API.
    /// </summary>
    public static class SecurityExtension
    {
        /// <summary>
        /// Registers the necessary security services, including Microsoft.AspNetCore.Identity, for the UMS API.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which security services are added.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> containing configuration settings.</param>
        /// <returns>The modified <see cref="IServiceCollection"/> with security services registered.</returns>
        public static IServiceCollection RegisterSecurityService(this IServiceCollection services, IConfiguration configuration)
        {
            // Identity Configuration
            services.AddIdentity<User, Role>(options =>
            {
                // Password requirements
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
            })
            // Use UMSDbContext for storing Identity data
            .AddEntityFrameworkStores<UMSDbContext>()
            // Add default token providers for features like password reset
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
