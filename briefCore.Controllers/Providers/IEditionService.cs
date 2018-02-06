namespace brief.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using briefCore.Controllers.Models;
    using briefCore.Controllers.Models.BaseEntities;
    using briefCore.Controllers.Providers;

    public interface IEditionService : IImageService
    {
        Task<BaseResponseMessage> CreateEdition(EditionModel edition);
        Task<BaseResponseMessage> RetrieveEditionDataFromImage(ImageModel image);
        Task<BaseResponseMessage> UpdateEdition(EditionModel edition);
        Task<BaseResponseMessage> RemoveEdition(Guid id);
    }
}
