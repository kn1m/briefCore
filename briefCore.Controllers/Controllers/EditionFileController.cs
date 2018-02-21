namespace briefCore.Controllers.Controllers
{
    using System.IO.Abstractions;
    using BaseControllers;

    public class EditionFileController : BaseFileUploadController
    {
        public EditionFileController(IFileSystem fileSystem) : base(fileSystem)
        {
            
        }
    }
}
