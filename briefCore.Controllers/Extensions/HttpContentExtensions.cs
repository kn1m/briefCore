namespace briefCore.Controllers.Extensions
{
    using System.Net.Http;

    //TODO: what is original purpose of this code?
    public static class HttpContentExtensions
    {
        public static bool IsTextFilesContent(this HttpContent requestContent)
        {
            return true;
        }

        public static bool IsImageFilesContent(this HttpContent requestContent)
        {
            return true;
        }
    }
}
