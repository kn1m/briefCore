namespace briefCore.Controllers.Middleware
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using log4net;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class ExceptionHandlingMiddleware
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExceptionHandlingMiddleware));
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //TODO: handle exceptions of specific types
            _logger.Error(exception.Message + Environment.NewLine + exception.StackTrace);
            
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            return context.Response.WriteAsync(result);
        }
    }
}