namespace briefCore.Library.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface INoteRepository
    {
        Task<Guid> CreateNote(Note note);
        Task<Guid> UpdateNote(Note note);
        Task RemoveNote(Guid id);
        
        Task<List<Guid>> CreateMultipleNotes(IList<Note> notes);
    }
}
