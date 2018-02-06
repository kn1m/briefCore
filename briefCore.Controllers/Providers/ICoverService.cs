namespace brief.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using briefCore.Controllers.Models;
    using briefCore.Controllers.Models.BaseEntities;
    using briefCore.Controllers.Providers;

    public interface ICoverService : IImageService
    {
        Task<BaseResponseMessage> SaveCover(ImageModel image);
        Task<BaseResponseMessage> RetrieveDataFromCover(ImageModel cover);
        Task<BaseResponseMessage> RemoveCover(Guid id);
    }
}
