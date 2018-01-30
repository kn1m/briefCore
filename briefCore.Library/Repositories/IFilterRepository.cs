namespace brief.Library.Repositories
{
    using System;
    using System.Linq;
    using briefCore.Library.Entities;
    using Entities;

    public interface IFilterRepository
    {
        IQueryable<Book> GetBooks();
        IQueryable<Book> GetBookById(Guid id);
        Cover GetCoverById(Guid id);
    }
}
