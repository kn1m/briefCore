using System.Net;
using System.Net.Http;

namespace briefCore.Controllers.Extensions
{
    using Models.BaseEntities;

    public static class BaseResponseExtensions
    {
        public static HttpResponseMessage CreateRespose(this BaseResponseMessage result, HttpStatusCode success,
            HttpStatusCode failure)
        {
            if (result.RawData != null)
            {
                return new HttpResponseMessage { StatusCode = failure, ReasonPhrase = result.RawData};
            }

            return new HttpResponseMessage { StatusCode = success, ReasonPhrase = result.Id.ToString()};
        }
    }
}
