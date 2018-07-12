namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface IEditionService : IImageService
    {
        Task<BaseResponseMessage> CreateEdition([NotNull]EditionModel edition);
        Task<BaseResponseMessage> UpdateEdition([NotNull]EditionModel edition);
        Task<BaseResponseMessage> RemoveEdition(Guid id);

        Task<BaseResponseMessage> RetrieveEditionDataFromImage(ImageModel image);
        
        Task<BaseResponseMessage> AddEditionFile(Guid id, string editionPath);
        Task<BaseResponseMessage> UpdateEditionFile(Guid id, string editionPath);
        Task<BaseResponseMessage> RemoveEditionFile(Guid id);
    }
}
