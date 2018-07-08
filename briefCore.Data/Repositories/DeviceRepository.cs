namespace briefCore.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Library.Entities;
    using Library.Repositories;
    
    public class DeviceRepository : IDeviceRepository
    {
        public DeviceRepository()
        {
            
        }

        public Task<Guid> CreateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDevice(Device device)
        {
            throw new NotImplementedException();
        }
    }
}