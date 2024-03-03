namespace UMS.Api.Extensions
{
    using UMS.Core.Interfaces;
    using UMS.Core.Services;
    using UMS.Infrastructure.DTOs;
    using UMS.Infrastructure.Interfaces;
    using UMS.Infrastructure.Repositories;

    /// <summary>
    /// Extension methods for configuring and registering services and repositories in the UMS API.
    /// </summary>
    public static class ServiceExtension
    {
        /// <summary>
        /// Registers various services and repositories necessary for the functionality of the UMS API.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which services and repositories are added.</param>
        /// <returns>The modified <see cref="IServiceCollection"/> with services and repositories registered.</returns>
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            // Registering singleton and scoped services
            services.AddSingleton<IUserContext, UserContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

            #region Repositories
            // Registering transient repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            #endregion

            return services;
        }
    }
}