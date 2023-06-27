using HomeAccountingPL.Middleware;

namespace HomeAccountingPL.Extensions
{
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(
            this IApplicationBuilder app,
            string errorHandlingPath)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>(errorHandlingPath);
        }
    }
}
