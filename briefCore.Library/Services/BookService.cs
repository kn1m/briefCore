namespace briefCore.Library.Services
{
    using System;
    using System.IO.Abstractions;
    using System.Threading.Tasks;
    using AutoMapper;
    using BaseServices;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Providers.ServiceProviders;
    using Entities;
    using Helpers;
    using JetBrains.Annotations;
    using UnitOfWork;

    public class BookService : BaseFileService, IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public BookService([NotNull]IUnitOfWork unitOfWork,
                           [NotNull]IFileSystem fileSystem,
                           [NotNull]IMapper mapper) : base(fileSystem)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));
            Guard.AssertNotNull(mapper, nameof(mapper));

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseMessage<(Guid authorId, Guid bookId)>> AddAuthorForBook(Guid authorId, Guid bookId)
        {
            var authorRepository = _unitOfWork.GetAuthorRepository();
            
            var response = new ResponseMessage<(Guid authorId, Guid bookId)>();

            if (!await authorRepository.CheckAvailabilityAddingAuthorToBook(authorId, bookId))
            {
                response.RawData = $"Can't add author with id {authorId} to book with id {bookId}";
                return response;
            }

            response.Payload = await authorRepository.AddAuthorToBook(authorId, bookId);
            return response;
        }

        public async Task<ResponseMessage<(Guid authorId, Guid bookId)>> RemoveAuthorFromBook(Guid authorId, Guid bookId)
        {
            var authorRepository = _unitOfWork.GetAuthorRepository();
            
            var response = new ResponseMessage<(Guid authorId, Guid bookId)>();

            if (await authorRepository.RemoveAuthorFromBook(authorId, bookId) == 0)
            {
                response.RawData = $"Linked record with author id {authorId} and book with id {bookId} wasn't found.";
                return response;
            }

            response.Payload = (authorId, bookId);
            return response;
        }

        public async Task<BaseResponseMessage> CreateBook(BookModel book, bool force = false)
        {
            var bookRepository = _unitOfWork.GetBookRepository();
            
            var newBook = _mapper.Map<Book>(book);

            var response = new BaseResponseMessage();

            if (await bookRepository.CheckBookForUniqueness(newBook) && !force)
            {
                response.RawData = $"Book {newBook.Name} already existing with similar data.";
                return response;
            }

            var createdBookId = await bookRepository.CreateBook(newBook);

            response.Id = createdBookId;
            return response;
        }

        public async Task<BaseResponseMessage> UpdateBook(BookModel book)
        {
            var bookRepository = _unitOfWork.GetBookRepository();
            
            var newBook = _mapper.Map<Book>(book);

            var response = new BaseResponseMessage();

            var bookToUpdate = await bookRepository.GetBook(newBook.Id);

            if (bookToUpdate == null)
            {
                response.RawData = $"Book with {newBook.Id} wasn't found.";
                return response;
            }
            
            if (bookToUpdate.Equals(newBook))
            {
                response.RawData = $"Book {newBook.Name} already existing with similar data.";
                return response;
            }

            await bookRepository.UpdateBook(newBook);

            response.Id = newBook.Id;
            return response;
        }

        public async Task<BaseResponseMessage> RemoveBook(Guid id)
        {
            var bookRepository = _unitOfWork.GetBookRepository();
            var editionRepository = _unitOfWork.GetEditionRepository();
            var coverRepository = _unitOfWork.GetCoverRepository();
            
            var response = new BaseResponseMessage();

            var bookToRemove = await bookRepository.GetBook(id);

            if (bookToRemove == null)
            {
                response.RawData = $"Book with {id} wasn't found.";
                return response;
            }

            var editionsToRemove = await editionRepository.GetEditionsByBookOrPublisher(id);

            if (editionsToRemove != null)
            {
                editionsToRemove.ForEach(async e =>
                {
                    var covers = await coverRepository.GetCoversByEdition(e.Id);

                    if (covers != null)
                    {
                        covers.ForEach(c => TryCleanUp(c.LinkTo));

                        await coverRepository.RemoveCovers(covers);
                    }
                });
                
                await editionRepository.RemoveEditions(editionsToRemove);
            }

            await bookRepository.RemoveBook(bookToRemove);

            response.Id = id;
            return response;
        }
    }
}
