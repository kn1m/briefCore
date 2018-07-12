namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Models;
    using Models.BaseEntities;

    public interface IDeviceService
    {
        Task<BaseResponseMessage> CreateDevice([NotNull]DeviceModel device);
        Task<BaseResponseMessage> UpdateDevice([NotNull]DeviceModel device);
        Task<BaseResponseMessage> RemoveDevice(Guid id);

        Task<BaseResponseMessage> CreateUserDevice([NotNull] UserDeviceModel userDevice, Guid userId);
        Task<BaseResponseMessage> UpdateUserDevice([NotNull] UserDeviceModel userDevice, Guid userId);
        Task<BaseResponseMessage> CreateUserDevice(Guid userDeviceId, Guid userId);
    }
}