namespace briefCore.Library.Services
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Controllers.Models;
    using Controllers.Models.BaseEntities;
    using Controllers.Providers.ServiceProviders;
    using Helpers;
    using JetBrains.Annotations;
    using UnitOfWork;

    public class DeviceService : IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public DeviceService([NotNull]IUnitOfWork unitOfWork,
                             [NotNull]IMapper mapper)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));
            Guard.AssertNotNull(mapper, nameof(mapper));

            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public Task<BaseResponseMessage> CreateUserDevice(UserDeviceModel userDevice, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> UpdateUserDevice(UserDeviceModel userDevice, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> CreateUserDevice(Guid userDeviceId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}