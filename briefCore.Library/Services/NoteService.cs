namespace briefCore.Library.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using brief.Library.Repositories;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Models.Enums;
    using Controllers.Providers;
    using Repositories;

    public class NoteService : INoteService
    {
        public NoteService(INoteRepository noteRepository)
        {
            
        }

        public Task<BaseResponseMessage> CreateNote(NoteModel note)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> UpdateNote(NoteModel note)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> RemoveNote(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> ImportNotes(IList<NoteModel> notes, NoteTypeModel noteType)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> SaveNotesFile(string notesFilePath, NoteTypeModel noteType)
        {
            throw new NotImplementedException();
        }
    }
}
