namespace briefCore.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using Models.BaseEntities;

    public interface IEditionService : IImageService
    {
        Task<BaseResponseMessage> CreateEdition(EditionModel edition);
        Task<BaseResponseMessage> UpdateEdition(EditionModel edition);
        Task<BaseResponseMessage> RemoveEdition(Guid id);

        Task<BaseResponseMessage> RetrieveEditionDataFromImage(ImageModel image);
        
        Task<BaseResponseMessage> AddEditionFile(Guid id, string editionPath);
        Task<BaseResponseMessage> UpdateEditionFile(Guid id, string editionPath);
        Task<BaseResponseMessage> RemoveEditionFile(Guid id);
    }
}
