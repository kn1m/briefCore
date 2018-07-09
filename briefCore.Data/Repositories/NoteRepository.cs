namespace briefCore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BaseRepositories;
    using JetBrains.Annotations;
    using Library.Entities;
    using Library.Repositories;

    public class NoteRepository : BaseDapperRepository, INoteRepository
    {
        public NoteRepository([NotNull]string connectionString) : base(connectionString) {}

        public Task<Guid> CreateNote([NotNull]Note note)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateNote([NotNull]Note note)
        {
            throw new NotImplementedException();
        }

        public Task RemoveNote(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> CreateMultipleNotes([NotNull]IList<Note> notes)
        {
            throw new NotImplementedException();
        }
    }
}
