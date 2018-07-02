namespace briefCore.Library.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;

    public interface IEditionFileRepository
    {
        Task<EditionFile> GetEditionFile(Guid id);
        Task<Guid> CreateEditionFile(EditionFile editionFile);
        Task<Guid> UpdateEditionFile(EditionFile editionFile);
        Task RemoveEditionFile(EditionFile editionFile);
    }
}
