namespace briefCore.Library.Services
{
    using AutoMapper;
    using Controllers.Providers.ServiceProviders;
    using Helpers;
    using UnitOfWork;

    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public AccountService(IMapper mapper, 
                              IUnitOfWork unitOfWork)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));
            Guard.AssertNotNull(mapper, nameof(mapper));

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}