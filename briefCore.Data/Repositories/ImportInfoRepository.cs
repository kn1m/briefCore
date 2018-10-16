namespace briefCore.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using BaseRepositories;
    using Contexts.Interfaces;
    using Library.Entities;
    using Library.Repositories;
    
    public class ImportInfoRepository : BaseEntityFrameworkRepository, IImportInfoRepository
    {
        public ImportInfoRepository(IApplicationDbContext context) : base(context)
        {
            
        }

        public Task<ImportInfo> GetImportInfo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ImportInfo> CreateImportInfo(ImportInfo importInfo)
        {
            throw new NotImplementedException();
        }

        public Task<ImportInfo> UpdateImportInfo(ImportInfo importInfo)
        {
            throw new NotImplementedException();
        }

        public Task RemoveImportInfo(ImportInfo importInfo)
        {
            throw new NotImplementedException();
        }
    }
}