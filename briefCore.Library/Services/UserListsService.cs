namespace briefCore.Library.Services
{
    using System;
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
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}