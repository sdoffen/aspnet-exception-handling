using Microsoft.AspNetCore.Diagnostics;

namespace ExceptionHandlingDemo.Api;

public class CustomExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> _logger;

    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    {
        this._logger = logger;
    }

    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("Error: {message} at {time}", exception.Message, DateTime.UtcNow);

        // return false to continue with the default behavior
        // return true to signal that the exception is handled

        // We return false so that after the exception is logged
        // the default behavior of showing the exception page
        // still happens
        return ValueTask.FromResult(false);
    }
}
