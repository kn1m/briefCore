namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface ICoverService : IImageService
    {
        Task<BaseResponseMessage> SaveCover([NotNull]ImageModel image);
        Task<BaseResponseMessage> RetrieveDataFromCover([NotNull]ImageModel cover);
        Task<BaseResponseMessage> RemoveCover(Guid id);
    }
}
