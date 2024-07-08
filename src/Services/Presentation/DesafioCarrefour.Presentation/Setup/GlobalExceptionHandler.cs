using DesafioCarrefour.Core.DomainObjects;
using Microsoft.AspNetCore.Diagnostics;

namespace DesafioCarrefour.WebApi.Setup;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        (int statusCode, string errorMessage) = exception switch
        {
            ArgumentNullException argumentException => (500, argumentException.Message),
            DomainException domainException => (500, domainException.Message),
            _ => (500, "Something went wrong")
        };

        logger.LogError(exception, exception.Message);
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(errorMessage, cancellationToken);
        return true;
    }
}