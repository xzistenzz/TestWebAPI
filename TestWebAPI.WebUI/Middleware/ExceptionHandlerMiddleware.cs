using System.Net;
using TestWebAPI.Domain.Exepctions;

namespace TestWebAPI.WebUI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (NotFoundEntityException ex) 
            { 
                _logger.LogWarning(ex.Message);
                await HandlerNotFoundEntityExceptionAsync(ex, context);
            }
            catch (PasswordIncorrectException ex)
            {
                await HandlerPasswordIncorrectException(ex, context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandlerExceptionAsync(ex, context);
            }
        }

        private async Task HandlerNotFoundEntityExceptionAsync(NotFoundEntityException ex, HttpContext context)
        {
            var code = HttpStatusCode.BadRequest;
            var response = new
            {
                code,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(response);
        }

        private async Task HandlerExceptionAsync(Exception ex, HttpContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            var response = new
            {
                code,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(response);
        }

        private async Task HandlerPasswordIncorrectException(PasswordIncorrectException ex, HttpContext context)
        {
            var code = HttpStatusCode.BadRequest;
            var response = new
            {
                code,
                message = ex.Message,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
