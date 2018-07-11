namespace briefCore.Controllers.Providers
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
    }
}