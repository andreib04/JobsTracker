using System.Net;
using System.Text.Json;

namespace JobsTracker.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = exception switch
            {
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                ArgumentException => HttpStatusCode.BadRequest,
                KeyNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                statusCode = response.StatusCode
            });

            return response.WriteAsync(result);
        }
    }
}
