﻿namespace briefCore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using brief.Library.Repositories;
    using BaseRepositories;
    using Library.Entities;

    public class NoteRepository : BaseDapperRepository, INoteRepository
    {
        public NoteRepository(string connectionString) : base(connectionString) {}

        public List<Guid> AddMultipleNotes(IList<Note> notes)
        {
            throw new NotImplementedException();
        }
    }
}
