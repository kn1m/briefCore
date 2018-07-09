namespace briefCore.Controllers.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Models.BaseEntities;
    using Models.Enums;

    public interface INoteService
    {
        Task<BaseResponseMessage> CreateNote(NoteModel note);
        Task<BaseResponseMessage> UpdateNote(NoteModel note);
        Task<BaseResponseMessage> RemoveNote(Guid id);
        
        Task<BaseResponseMessage> ImportNotes(IList<NoteModel> notes, NoteTypeModel noteType);
        Task<BaseResponseMessage> SaveNotesFile(string notesFilePath, NoteTypeModel noteType);
    }
}