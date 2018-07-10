namespace briefCore.Controllers.Providers
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using Models.BaseEntities;

    public interface IDeviceService
    {
        Task<BaseResponseMessage> CreateDevice(DeviceModel device);
        Task<BaseResponseMessage> UpdateDevice(DeviceModel device);
        Task<BaseResponseMessage> RemoveDevice(Guid id);
    }
}