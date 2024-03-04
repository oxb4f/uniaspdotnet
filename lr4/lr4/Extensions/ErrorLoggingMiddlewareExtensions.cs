namespace lr4.Extensions;

using lr4.Middleware;


using Microsoft.AspNetCore.Builder;

public static class ErrorLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorLoggingMiddleware>();
    }
}