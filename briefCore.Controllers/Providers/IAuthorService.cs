namespace briefCore.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using brief.Controllers.Models;
    using brief.Controllers.Models.BaseEntities;

    public interface IAuthorService
    {
        Task<BaseResponseMessage> CreateAuthor(AuthorModel author);
        Task<BaseResponseMessage> UpdateAuthor(AuthorModel author);
        Task<BaseResponseMessage> RemoveAuthor(Guid id, bool removeEditions = false);
    }
}