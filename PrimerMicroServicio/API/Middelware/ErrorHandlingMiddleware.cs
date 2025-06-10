using System.Text.Json;
using PrimerMicroServicio.Domain.Exceptions;

namespace PrimerMicroServicio.API.Middelware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
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
            
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
