namespace briefCore.Controllers.Controllers
{
    using System;
    using System.IO.Abstractions;
    using System.Threading.Tasks;
    using BaseControllers;
    
    public class ExportController : BaseFileUploadController
    {
        public ExportController(IFileSystem fileSystem) : base(fileSystem)
        {
            
        }

        public Task<Guid> Add()
        {
            return null;
        } 
    }
}