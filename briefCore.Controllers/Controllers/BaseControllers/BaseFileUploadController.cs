namespace briefCore.Controllers.Controllers.BaseControllers
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseFileUploadController : Controller
    {
        private readonly IFileSystem _fileSystem;
        
        protected BaseFileUploadController(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public virtual async Task<HttpResponseMessage> UploadFiles(List<IFormFile> files)
        {
            if(Request.GetMultipartBoundary() == null)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.UnsupportedMediaType };
            }

            return null;
        }
    }
}