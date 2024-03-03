/// <summary>
/// Extension methods for logging middleware.
/// </summary>
namespace UMS.Api.Extensions
{
    using UMS.Api.Middlewares;

    /// <summary>
    /// Extension methods for adding logging middleware to the application.
    /// </summary>
    public static class LoggingMiddlewareExtension
    {
        /// <summary>
        /// Adds the logging middleware to the application.
        /// </summary>
        /// <param name="builder">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}