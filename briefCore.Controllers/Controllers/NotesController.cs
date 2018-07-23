namespace briefCore.Controllers.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO.Abstractions;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BaseControllers;
    using Microsoft.AspNetCore.Authorization;
    using Models;
    using Providers.ServiceProviders;

    [Authorize]
    public class NotesController : BaseFileUploadController
    {
        private readonly INoteService _noteService;
        
        public NotesController(INoteService noteService, 
                               IFileSystem fileSystem) : base(fileSystem)
        {
            _noteService = noteService ?? throw new ArgumentNullException(nameof(noteService));
        }

        public Task<HttpResponseMessage> ImportNotes(List<NoteModel> notes)
        {
            return null;
        }
    }
}