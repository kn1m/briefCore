namespace briefCore.Controllers.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;
    using Models.Enums;

    public interface INoteService
    {
        Task<BaseResponseMessage> CreateNote([NotNull]NoteModel note);
        Task<BaseResponseMessage> UpdateNote([NotNull]NoteModel note);
        Task<BaseResponseMessage> RemoveNote(Guid id);
        
        Task<BaseResponseMessage> ImportNotes([NotNull]IList<NoteModel> notes, NoteTypeModel noteType);
        Task<BaseResponseMessage> SaveNotesFile(string notesFilePath, NoteTypeModel noteType);
    }
}