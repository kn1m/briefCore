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

    public class EditionService : BaseTransformService, IEditionService
    {
        public StorageSettings StorageSettings { get; }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransformer<string, string> _transformer;
        private readonly IMapper _mapper;

        public EditionService([NotNull]IUnitOfWork unitOfWork,
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

        public async Task<BaseResponseMessage> RetrieveEditionDataFromImage([NotNull]ImageModel image)
        {
            var imagePath = ConvertToAppropirateFormat(image.Path, deleteOriginal: true);

            string transformResult = await _transformer.TransformAsync(imagePath, image.TargetLanguage);

            TryCleanUp(imagePath);

            return new BaseResponseMessage { RawData = transformResult };
        }

        public async Task<BaseResponseMessage> AddEditionFile(Guid id, [NotNull]string editionPath)
        {
            var editionRepository = _unitOfWork.GetEditionRepository();
            
            var edition = await editionRepository.GetEdition(id);


            return null;
        }

        public Task<BaseResponseMessage> UpdateEditionFile(Guid id, [NotNull]string editionPath)
        {   
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> RemoveEditionFile(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseMessage> UpdateEdition([NotNull]EditionModel edition)
        {
            var editionRepository = _unitOfWork.GetEditionRepository();
            
            var newEdition = _mapper.Map<Edition>(edition);

            var response = new BaseResponseMessage();

            var editionToUpdate = await editionRepository.GetEdition(newEdition.Id);

            if (editionToUpdate == null)
            {
                response.RawData = $"Edition with {newEdition.Id} wasn't found.";
                return response;
            }
            
            if (newEdition.Equals(editionToUpdate))
            {
                response.RawData = $"Edition {newEdition.Description} already existing with similar data.";
                return response;
            }

            await editionRepository.UpdateEdition(newEdition);

            response.Id = newEdition.Id;
            return response;
        }

        public async Task<BaseResponseMessage> RemoveEdition(Guid id)
        {
            var editionRepository = _unitOfWork.GetEditionRepository();
            var coverRepository = _unitOfWork.GetCoverRepository();
            
            var response = new BaseResponseMessage();

            var editionToRemove = await editionRepository.GetEdition(id);

            if (editionToRemove == null)
            {
                response.RawData = $"Edition with {id} wasn't found.";
                return response;
            }
            
            var covers = await coverRepository.GetCoversByEdition(id);

            if (covers != null)
            {
                covers.ForEach(c => TryCleanUp(c.LinkTo));

                await coverRepository.RemoveCovers(covers);
            }
            
            await editionRepository.RemoveEdition(editionToRemove);
            
            response.Id = id;
            return response;
        }

        public Task<BaseResponseMessage> UploadEditionFile(Guid id, [NotNull]string editionPath)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseMessage> CreateEdition(EditionModel edition)
        {
            var editionRepository = _unitOfWork.GetEditionRepository();
            
            var newEdtition = _mapper.Map<Edition>(edition);

            var response = new BaseResponseMessage();

            if (await editionRepository.CheckEditionForUniqueness(newEdtition))
            {
                response.RawData = $"Edition {newEdtition.Description} already existing with similar data.";
                return response;
            }

            var createdEditionId = await editionRepository.CreateEdition(newEdtition);

            response.Id = createdEditionId;
            return response;
        }
    }
}
