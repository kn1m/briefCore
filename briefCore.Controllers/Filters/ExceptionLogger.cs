﻿/*namespace briefCore.Controllers.Filters
{
    using System.Threading;
    using System.Threading.Tasks;
    using log4net;

    public class ExceptionLogger : IExceptionLogger
    {
        private readonly ILog _logger;

        public ExceptionLogger(ILog logger)
        {
            _logger = logger;
        }

        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
            => Task.Run(() => {
                _logger.Error($"Unhandled exception thrown in {context.Request.Method} for request {context.Request.RequestUri}: {context.Exception}");
                              });
        
    }
}*/