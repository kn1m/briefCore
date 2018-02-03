﻿namespace brief.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using briefCore.Controllers.Models;
    using briefCore.Controllers.Models.BaseEntities;

    public interface INoteService
    {
        Task<BaseResponseMessage> CreateNote(NoteModel note);
        Task<BaseResponseMessage> UpdateNote(NoteModel note);
        Task<BaseResponseMessage> RemoveNote(Guid id);
    }
}