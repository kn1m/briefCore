namespace briefCore.Library.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IDeviceRepository
    {
        Task<Guid> CreateDevice(Device device);
        Task<Guid> UpdateDevice(Device device);
        Task RemoveDevice(Device device);
    }
}