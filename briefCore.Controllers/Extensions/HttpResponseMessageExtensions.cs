namespace briefCore.Controllers.Extensions
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using brief.Controllers.Models;
    using Microsoft.AspNetCore.StaticFiles;
    
    public static class HttpResponseMessageExtensions
    {
        public static HttpResponseMessage RetrieveContentFromCover(this HttpResponseMessage response, CoverModel cover)
        {
            string GetMimeType(string pathToFile)
            {
                new FileExtensionContentTypeProvider().TryGetContentType(pathToFile, out var contentType);
                return contentType ?? "application/octet-stream";
            }
            
            StreamContent content = new StreamContent(new FileStream(cover.LinkTo, FileMode.Open));

            response.Content = content;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(GetMimeType(cover.LinkTo));
            response.StatusCode = HttpStatusCode.OK;

            return response;
        }
    }
}
