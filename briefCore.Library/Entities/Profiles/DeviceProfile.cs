namespace briefCore.Library.Entities.Profiles
{
    using System;
    using AutoMapper;
    using Controllers.Models;

    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceModel, Device>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id ?? Guid.NewGuid()));

            CreateMap<Device, DeviceModel>();            
        }
    }
}