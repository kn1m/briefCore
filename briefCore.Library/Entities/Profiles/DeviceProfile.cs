namespace briefCore.Library.Entities.Profiles
{
    using AutoMapper;
    using Controllers.Models;

    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceModel, Device>();
            CreateMap<Device, DeviceModel>();            
        }
    }
}