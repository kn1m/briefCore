namespace briefCore.Controllers.Controllers
{
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BaseControllers;
    using Models;

    public class NotesController : BaseFileUploadController
    {
        public NotesController(IFileSystem fileSystem) : base(fileSystem)
        {
            
        }

        public Task<HttpResponseMessage> ExportNotes(List<NoteModel> notes)
        {
            return null;
        }
    }
}