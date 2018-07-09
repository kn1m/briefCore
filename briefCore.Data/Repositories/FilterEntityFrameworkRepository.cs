namespace briefCore.Data.Repositories
{
    using System;
    using System.Linq;
    using BaseRepositories;
    using Contexts.Interfaces;
    using Library.Entities;
    using Library.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class FilterEntityFrameworkRepository : BaseEntityFrameworkRepository, IFilterRepository
    {
        public FilterEntityFrameworkRepository(IApplicationDbContext appContext) : base(appContext) {}

        public IQueryable<Book> GetBooks()
            => Context.Set<Book>();

        //TODO: to checkout
        public IQueryable<Book> GetBookById(Guid id)
            => Context.Set<Book>().Where(b => b.Id == id)
                .Include(b => b.BookInSerieses)
                .Include(b => b.BookByAuthors)
                .Include(b => b.Editions);

        public Cover GetCoverById(Guid id)
            => Context.Set<Cover>().Find(id);
    }
}
