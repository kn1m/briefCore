namespace briefCore.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using BaseRepositories;
    using Contexts.Interfaces;
    using Library.Entities;
    using Library.Repositories;
    
    public class DeviceRepository : BaseEntityFrameworkRepository, IDeviceRepository
    {
        public DeviceRepository(IApplicationDbContext context) : base(context) {}

        public async Task<Guid> CreateDevice(Device device)
        {
            var newDevice = Add(device);
            await Commit();

            return newDevice.Entity.Id;
        }

        public async Task<Guid> UpdateDevice(Device device)
        {
            Update(device);
            await Commit();

            return device.Id;
        }

        public async Task RemoveDevice(Device device)
        {
            Remove(device);
            await Commit();
        }
    }
}