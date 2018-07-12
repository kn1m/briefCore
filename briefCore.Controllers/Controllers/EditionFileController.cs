namespace briefCore.Controllers.Controllers
{
    using System;
    using System.IO.Abstractions;
    using BaseControllers;
    using Microsoft.AspNetCore.Authorization;
    using Providers;
    using Providers.ServiceProviders;

    [Authorize]
    public class EditionFileController : BaseFileUploadController
    {
        private readonly IEditionService _editionService;
        
        public EditionFileController(IEditionService editionService, 
                                     IFileSystem fileSystem) : base(fileSystem)
        {
            _editionService = editionService ?? throw new ArgumentNullException(nameof(editionService));
        }
    }
}
