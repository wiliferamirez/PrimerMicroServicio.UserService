using System.Text.Json;
using PrimerMicroServicio.Domain.Exceptions;

namespace PrimerMicroServicio.API.Middelware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught by Middleware");
            context.Response.ContentType = "application/json";
            var response = new
            {

                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Something went wrong, Try again later"
            };

            if (ex is UserAlreadyExistsException)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                response = new
                {
                    StatusCode = 409,
                    Message = ex.Message
                };
            }

            if (ex is InvalidCredentialsException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                response = new
                {
                    StatusCode = 401,
                    Message = ex.Message
                };
            }
            
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
