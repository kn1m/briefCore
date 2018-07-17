namespace briefCore.Library.Services
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Controllers.Models.BaseEntities;
    using Controllers.Models.Enums;
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

        public Task<BaseResponseMessage> SetDefaultLanguage(LanguageModel language, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseMessage> SetDefaultRecognitionLanguage(LanguageModel language, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}