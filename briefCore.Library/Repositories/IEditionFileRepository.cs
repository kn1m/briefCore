namespace brief.Library.Repositories
{
    using System;
    using System.Threading.Tasks;
    using briefCore.Library.Entities;
    using Entities;

    public interface IEditionFileRepository
    {
        Task<Guid> AddFile(EditionFile file);
        Task<EditionFile> GetFile();
    }
}
