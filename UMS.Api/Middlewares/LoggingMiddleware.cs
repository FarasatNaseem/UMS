using System.Security.Claims;
using System.Text;

namespace UMS.Api.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        //private readonly IUser_Context _userContext;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger/*, IUser_Context userContext*/)
        {
            _next = next;
            _logger = logger;
            //_userContext = userContext;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the incoming request
            LogRequest(context.Request);

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //_userContext.UserId = userId;

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the outgoing response
            LogResponse(context.Response);
        }

        private void LogRequest(HttpRequest request)
        {
            //_logger.LogInformation($"{_userContext.UserId} Request received: {request.Method} {request.Path}");
            //_logger.LogInformation($"{_userContext.UserId} Request headers: {GetHeadersAsString(request.Headers)}");
        }

        private void LogResponse(HttpResponse response)
        {
            //_logger.LogInformation($"{_userContext.UserId} Response sent: {response.StatusCode}");
            //_logger.LogInformation($"{_userContext.UserId} Response headers: {GetHeadersAsString(response.Headers)}");
        }

        private string GetHeadersAsString(IHeaderDictionary headers)
        {
            var stringBuilder = new StringBuilder();
            foreach (var (key, value) in headers)
            {
                stringBuilder.AppendLine($"{key}: {value}");
            }
            return stringBuilder.ToString();
        }
    }
}
