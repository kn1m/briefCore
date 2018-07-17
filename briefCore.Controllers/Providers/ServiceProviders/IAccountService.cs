namespace briefCore.Controllers.Providers.ServiceProviders
{
    using System;
    using System.Threading.Tasks;
    using Models.BaseEntities;
    using Models.Enums;

    public interface IAccountService
    {
        Task<BaseResponseMessage> SetDefaultLanguage(LanguageModel language, Guid userId);
        Task<BaseResponseMessage> SetDefaultRecognitionLanguage(LanguageModel language, Guid userId);
    }
}