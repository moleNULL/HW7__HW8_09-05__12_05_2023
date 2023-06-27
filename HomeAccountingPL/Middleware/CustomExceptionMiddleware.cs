namespace HomeAccountingPL.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        private readonly string _errorHandlingPath;

        public CustomExceptionMiddleware(
            RequestDelegate next,
            ILogger<CustomExceptionMiddleware> logger,
            string errorHandlingPath)
        {
            _next = next;
            _logger = logger;
            _errorHandlingPath = errorHandlingPath;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private void HandleException(HttpContext context, Exception exception)
        {
            string exceptionMessage = CreateExceptionMessage(exception);
            _logger.LogError(exceptionMessage);

            context.Response.Redirect(_errorHandlingPath);
        }

        private string CreateExceptionMessage(Exception exception)
        {
            string? stackTrace = exception.StackTrace;
            string? shortStackTraceInfo = stackTrace?.Substring(0, stackTrace.IndexOf(Environment.NewLine)).Trim();

            if (shortStackTraceInfo is null)
            {
                return $"ExceptionMessage: {exception.Message}";
            }

            return $"Exception {shortStackTraceInfo}.\n      ExceptionMessage: {exception.Message}";
        }
    }
}
