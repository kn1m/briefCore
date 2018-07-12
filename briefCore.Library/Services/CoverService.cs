namespace briefCore.Library.Services
{
    using System;
    using System.IO.Abstractions;
    using System.Threading.Tasks;
    using AutoMapper;
    using BaseServices;
    using Controllers.Helpers;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Providers;
    using Controllers.Providers.ServiceProviders;
    using Entities;
    using Helpers;
    using JetBrains.Annotations;
    using Transformers;
    using UnitOfWork;

    public class CoverService : BaseTransformService, ICoverService
    {
        public StorageSettings StorageSettings { get; }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransformer<string, string> _transformer;
        private readonly IMapper _mapper;

        public CoverService([NotNull]IUnitOfWork unitOfWork,
                            [NotNull]ITransformer<string, string> transformer,
                            [NotNull]IFileSystem fileSystem,
                            [NotNull]IMapper mapper,
                            [NotNull]BaseTransformerSettings settings,
                            [NotNull]StorageSettings storageSettings) : base(settings, fileSystem)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));
            Guard.AssertNotNull(transformer, nameof(transformer));
            Guard.AssertNotNull(mapper, nameof(mapper));
            Guard.AssertNotNull(storageSettings, nameof(storageSettings));

            StorageSettings = storageSettings;

            _unitOfWork = unitOfWork;
            _transformer = transformer;
            _mapper = mapper;
        }

        public async Task<BaseResponseMessage> SaveCover(ImageModel image)
        {
            var editionRepository = _unitOfWork.GetEditionRepository();
            var coverRepository = _unitOfWork.GetCoverRepository();
            
            var cover = _mapper.Map<Cover>(image);

            var response = new BaseResponseMessage();

            if (await editionRepository.GetEdition(cover.EditionId) == null)
            {
                response.RawData = $"Edition with id {cover.EditionId} couldn't been found.";
                return response;
            }

            response.Id = await coverRepository.SaveCover(cover);
            return response;
        }

        public async Task<BaseResponseMessage> RetrieveDataFromCover(ImageModel cover)
        {
            var imagePath = ConvertToAppropirateFormat(cover.Path, deleteOriginal: true);

            string transformResult = await _transformer.TransformAsync(imagePath, cover.TargetLanguage);

            TryCleanUp(imagePath);

            return new BaseResponseMessage { RawData = transformResult };
        }

        public async Task<BaseResponseMessage> RemoveCover(Guid id)
        {
            var coverRepository = _unitOfWork.GetCoverRepository();
            
            var response = new BaseResponseMessage();

            var coverToRemove = await coverRepository.GetCover(id);

            if (coverToRemove == null)
            {
                response.RawData = $"Cover with {id} wasn't found.";
                return response;
            }

            TryCleanUp(coverToRemove.LinkTo);

            await coverRepository.RemoveCover(coverToRemove);

            response.Id = id;
            return response;
        }
    }
}
