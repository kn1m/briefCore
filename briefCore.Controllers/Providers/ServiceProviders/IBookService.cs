namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface IBookService
    {
        Task<ResponseMessage<(Guid authorId, Guid bookId)>> AddAuthorForBook(Guid authorId, Guid bookId);
        Task<ResponseMessage<(Guid authorId, Guid bookId)>> RemoveAuthorFromBook(Guid authorId, Guid bookId);
        Task<BaseResponseMessage> CreateBook([NotNull]BookModel book, bool force = false);
        Task<BaseResponseMessage> UpdateBook([NotNull]BookModel book);
        Task<BaseResponseMessage> RemoveBook(Guid id);
    }
}
