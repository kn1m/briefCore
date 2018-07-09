namespace briefCore.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using BaseRepositories;
    using Library.Entities;
    using Library.Repositories;
    
    public class UserDeviceRepository : BaseDapperRepository, IUserDeviceRepository
    {
        public UserDeviceRepository(string connectionString) : base(connectionString)
        {
            
        }

        public Task<Guid> CreateUserDevice(UserDevice userDevice)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateUserDevice(UserDevice userDevice)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserDevice(UserDevice userDevice)
        {
            throw new NotImplementedException();
        }
    }
}