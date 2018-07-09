namespace briefCore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BaseRepositories;
    using Library.Entities;
    using Library.Repositories;

    public class NoteRepository : BaseDapperRepository, INoteRepository
    {
        public NoteRepository(string connectionString) : base(connectionString) {}

        public Task<Guid> CreateNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Task RemoveNote(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> CreateMultipleNotes(IList<Note> notes)
        {
            throw new NotImplementedException();
        }
    }
}
