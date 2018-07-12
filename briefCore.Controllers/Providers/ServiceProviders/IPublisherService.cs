namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface IPublisherService
    {
        Task<BaseResponseMessage> CreatePublisher([NotNull]PublisherModel publisher);
        Task<BaseResponseMessage> UpdatePublisher([NotNull]PublisherModel publisher);
        Task<BaseResponseMessage> RemovePublisher(Guid id);
    }
}
