namespace briefCore.Data.Repositories
{
    using System;
    using System.Linq;
    using brief.Library.Entities;
    using brief.Library.Repositories;
    using BaseRepositories;
    using Contexts.Interfaces;
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;

    public class FilterRepository : BaseRepository, IFilterRepository
    {
        public FilterRepository(IApplicationDbContext appContext) : base(appContext) {}

        public IQueryable<Book> GetBooks()
            => Context.Set<Book>();

        public IQueryable<Book> GetBookById(Guid id)
            => Context.Set<Book>().Where(b => b.Id == id)
                .Include(b => b.BookInSerieses)
                .Include(b => b.BookByAuthors)
                .Include(b => b.Editions);

        public Cover GetCoverById(Guid id)
            => Context.Set<Cover>().Find(id);
    }
}
