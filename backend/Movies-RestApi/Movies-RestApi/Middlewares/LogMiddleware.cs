
using System.Diagnostics;

namespace Movies_RestApi.Middlewares
{
    public class LogMiddleware : IMiddleware
    {
        private readonly ILogger _logger;
        public LogMiddleware(ILogger logger) 
        {
            _logger = logger;
        }
        

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _logger.LogInformation("▶️ Rozpoczęto żądanie: {method} {path}", context.Request.Method, context.Request.Path);

            try
            {
                await next(context);

                stopwatch.Stop();
                _logger.LogInformation("✅ Zakończono żądanie: {statusCode} w {elapsedMilliseconds}ms",
                    context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "❌ Wystąpił błąd podczas przetwarzania żądania: {message}", ex.Message);
                throw;
            }
        }
    }
}
