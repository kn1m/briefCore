namespace briefCore.Controllers.Filters
{
    using log4net;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ActionLogger : ActionFilterAttribute
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ActionLogger));
        private string _actionName;
        
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            _actionName = actionContext.ActionDescriptor.DisplayName;
            
            _logger.Info($"Action {_actionName} started");
        }

        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            _logger.Info($"Action {_actionName} was executed");
        }
    }
}
