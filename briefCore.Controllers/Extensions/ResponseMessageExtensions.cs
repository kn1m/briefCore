namespace briefCore.Controllers.Extensions
{
    using System.Net;
    using System.Net.Http;
    using brief.Controllers.Models.BaseEntities;

    public static class ResponseMessageExtensions
    {
        public static HttpResponseMessage CreateRespose<T>(this ResponseMessage<T> result, 
                                                           HttpStatusCode success,
                                                           HttpStatusCode failure)
            => result.RawData == null ?
                new HttpResponseMessage
                {
                    StatusCode = success,
                    ReasonPhrase = result.Payload.ToString() //TODO: implement handling of custom types
                } : 
                new HttpResponseMessage
                {
                    StatusCode = failure, 
                    ReasonPhrase = result.RawData   
                };
    }
}
