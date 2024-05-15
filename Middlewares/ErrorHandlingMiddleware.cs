using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using nike_clone_backend.Shared.ErrorsExceptions;

namespace nike_clone_backend.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string message;

            if (exception is CustomException customException)
            {
                statusCode = customException.StatusCode;
                message = customException.Message;
            }
            else
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                message = "An error occurred while processing your request.";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = JsonSerializer.Serialize(new { error = message });
            return context.Response.WriteAsync(result);
        }

    }
}