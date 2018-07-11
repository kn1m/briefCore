namespace briefCore.Library.Services
{
    using System;
    using System.IO.Abstractions;
    using System.Threading.Tasks;
    using AutoMapper;
    using BaseServices;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Providers;
    using Entities;
    using Helpers;
    using JetBrains.Annotations;
    using UnitOfWork;

    public class AuthorService : BaseFileService, IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService([NotNull]IUnitOfWork unitOfWork,
                             [NotNull]IFileSystem fileSystem,
                             [NotNull]IMapper mapper) : base(fileSystem)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));
            Guard.AssertNotNull(mapper, nameof(mapper));
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseMessage> CreateAuthor(AuthorModel author)
        {
            var authorRepository = _unitOfWork.GetAuthorRepository();
            
            var newAuthor = _mapper.Map<Author>(author);

            var response = new BaseResponseMessage();

            if (!await authorRepository.CheckAuthorForUniqueness(newAuthor))
            {
                response.RawData = $"Author {author.AuthorFirstName} {author.AuthorSecondName} {author.AuthorLastName} already exists.";
                return response;
            }

            var createdAuthorId = await authorRepository.CreateAuthor(newAuthor);

            response.Id = createdAuthorId;

            return response;
        }

        public async Task<BaseResponseMessage> UpdateAuthor(AuthorModel author)
        {
            var authorRepository = _unitOfWork.GetAuthorRepository();
            
            var newAuthor = _mapper.Map<Author>(author);

            var response = new BaseResponseMessage();

            if (!await authorRepository.CheckAuthorForUniqueness(newAuthor))
            {
                response.RawData = $"Author {author.AuthorFirstName} {author.AuthorSecondName} {author.AuthorLastName} already exists.";
                return response;
            }

            var updatedAuthorId = await authorRepository.UpdateAuthor(newAuthor);

            response.Id = updatedAuthorId;

            return response;
        }

        public async Task<BaseResponseMessage> RemoveAuthor(Guid id, bool removeEditions = false)
        {
            var authorRepository = _unitOfWork.GetAuthorRepository();
            var editionRepository = _unitOfWork.GetEditionRepository();
            var coverRepository = _unitOfWork.GetCoverRepository();
            
            var response = new BaseResponseMessage();

            var authorToRemove = await authorRepository.GetAuthor(id);

            if (authorToRemove == null)
            {
                response.RawData = $"Author with {id} wasn't found.";
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

            await authorRepository.RemoveAuthor(authorToRemove);

            response.Id = id;
            return response;
        }
    }
}
