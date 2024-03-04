namespace lr4.Middleware;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

public class ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorLoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            LogErrorToFile(ex);

            _logger.LogError(ex, "An error occurred while processing the request.");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            throw;
        }
    }

    private static void LogErrorToFile(Exception ex)
    {
        var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
        var logFilePath = Path.Combine(logDirectory, "error_log.txt");

        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        var logText = $"[{DateTime.Now}] Error: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";

        File.AppendAllText(logFilePath, logText);    }
}
