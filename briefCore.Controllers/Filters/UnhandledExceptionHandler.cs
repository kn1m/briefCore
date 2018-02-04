/*namespace briefCore.Controllers.Filters
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception != null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message)
                });
            }
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
            => true;
    }

    public class ExceptionHandler
    {
    }
}*/