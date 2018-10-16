namespace briefCore.Library.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IImportInfoRepository
    {
        Task<ImportInfo> GetImportInfo(Guid id);
        Task<ImportInfo> CreateImportInfo(ImportInfo importInfo);
        Task<ImportInfo> UpdateImportInfo(ImportInfo importInfo);
        Task RemoveImportInfo(ImportInfo importInfo);
    }
}