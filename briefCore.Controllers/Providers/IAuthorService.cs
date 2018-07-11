namespace briefCore.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface IAuthorService
    {
        Task<BaseResponseMessage> CreateAuthor([NotNull]AuthorModel author);
        Task<BaseResponseMessage> UpdateAuthor([NotNull]AuthorModel author);
        Task<BaseResponseMessage> RemoveAuthor(Guid id, bool removeEditions = false);
    }
}