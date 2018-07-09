namespace briefCore.Library.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IUserDeviceRepository
    {
        Task<Guid> CreateUserDevice(UserDevice userDevice);
        Task<Guid> UpdateUserDevice(UserDevice userDevice);
        Task RemoveUserDevice(UserDevice userDevice);
    }
}