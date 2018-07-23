namespace briefCore.Controllers.Controllers
{
    using System;
    using System.IO.Abstractions;
    using System.Net.Http;
    using BaseControllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Providers.ServiceProviders;

    [Authorize]
    [Route("api/[controller]/[action]")]
    public class EditionFileController : BaseFileUploadController
    {
        private readonly IEditionService _editionService;
        
        public EditionFileController(IEditionService editionService, 
                                     IFileSystem fileSystem) : base(fileSystem)
        {
            _editionService = editionService ?? throw new ArgumentNullException(nameof(editionService));
        }

        [HttpGet]
        public HttpResponseMessage GetEditionFile(Guid id)
        {
            return null;
        }
    }
}
