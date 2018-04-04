namespace briefCore.Controllers.Controllers
{
    using System.IO.Abstractions;
    using BaseControllers;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class EditionFileController : BaseFileUploadController
    {
        public EditionFileController(IFileSystem fileSystem) : base(fileSystem)
        {
            
        }
    }
}
