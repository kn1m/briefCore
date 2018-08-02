namespace briefCore.Library.Services
{
    using AutoMapper;
    using Controllers.Providers.ServiceProviders;
    using UnitOfWork;

    public class UserListsService : IUserListsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public UserListsService(IMapper mapper, 
                                IUnitOfWork unitOfWork)
        {
            
        }
    }
}