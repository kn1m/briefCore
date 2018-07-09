namespace briefCore.Library.Services
{
    using Controllers.Providers;
    using Helpers;
    using UnitOfWork;

    public class ImportInfoService : IInformInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ImportInfoService(IUnitOfWork unitOfWork)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }    
    }
}