namespace briefCore.Controllers.Extensions
{
    using System.Linq;
    using Helpers.Base;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;

    public static class RequestExtensions
    {
        public static string RetrieveHeader(this HttpRequest request,
                                                 string header,
                                                 IHeaderSettings settings)
        {
            if(request.Headers.TryGetValue(header, out StringValues headerValues))
            {
                var headersList = headerValues.ToList();

                if (headersList.Count != 1)
                {
                    return null;
                }

                var headerValue = headersList.FirstOrDefault();

                if (!settings.AcceptableValuesForHeader[header].Contains(headerValue?.ToLower()))
                {
                    return null;
                }

                return headerValue;
            }

            return null;
        }
    }
}
