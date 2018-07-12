namespace briefCore.Library.Services
{
    using Controllers.Providers;
    using Controllers.Providers.ServiceProviders;
    using Helpers;
    using UnitOfWork;

    public class ImportInfoService : IImportInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ImportInfoService(IUnitOfWork unitOfWork)
        {
            Guard.AssertNotNull(unitOfWork, nameof(unitOfWork));

            _unitOfWork = unitOfWork;
        }    
    }
}