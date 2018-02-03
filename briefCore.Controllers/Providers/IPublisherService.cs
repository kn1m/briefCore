﻿namespace brief.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using briefCore.Controllers.Models;
    using briefCore.Controllers.Models.BaseEntities;

    public interface IPublisherService
    {
        Task<BaseResponseMessage> CreatePublisher(PublisherModel publisher);
        Task<BaseResponseMessage> UpdatePublisher(PublisherModel publisher);
        Task<BaseResponseMessage> RemovePublisher(Guid id);
    }
}
