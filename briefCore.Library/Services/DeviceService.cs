namespace briefCore.Library.Services
{
    using System;
    using System.Threading.Tasks;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Providers;
    using UnitOfWork;

    public class DeviceService : IDeviceService
    {
        public DeviceService(IUnitOfWork unitOfWork)
        {
            
        }

        public Task<BaseResponseMessage> CreateDevice(DeviceModel device)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> UpdateDevice(DeviceModel device)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> RemoveDevice(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}