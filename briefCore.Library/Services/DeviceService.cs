namespace briefCore.Library.Services
{
    using System;
    using System.Threading.Tasks;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Providers;
    using Helpers;
    using UnitOfWork;

    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork; 
        
        public DeviceService(IUnitOfWork unitOfWork)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));

            _unitOfWork = unitOfWork;
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

        public Task<BaseResponseMessage> CreateUserDevice()
        {
            return null;
        }
    }
}