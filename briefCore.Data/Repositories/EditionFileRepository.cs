namespace briefCore.Data.Repositories
{
    using System;
    using System.Threading.Tasks;
    using brief.Library.Repositories;
    using Library.Entities;

    class EditionFileRepository : IEditionFileRepository
    {
        public EditionFileRepository()
        {
            
        }

        public Task<Guid> AddFile(EditionFile file)
        {
            return null;
        }

        public Task<EditionFile> GetFile()
        {
            throw new NotImplementedException();
        }
    }
}
