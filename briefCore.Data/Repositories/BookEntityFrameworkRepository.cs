namespace briefCore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using brief.Library.Entities;
    using brief.Library.Repositories;
    using BaseRepositories;
    using Contexts.Interfaces;
    using Library.Entities;
    using Library.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class BookEntityFrameworkRepository : BaseEntityFrameworkRepository, IBookRepository
    {
        public BookEntityFrameworkRepository(IApplicationDbContext context) : base(context) {}

        public Task<Book> GetBook(Guid id)
            => Context.Set<Book>().FindAsync(id);

        public Task<bool> CheckBookForUniqueness(Book book)
            => Context.Set<Book>().AnyAsync(b => b.Name == book.Name);
            
        public async Task<Guid> CreateBook(Book book)
        {
            var newBook = Add(book);
            await Commit();

            return newBook.Entity.Id;
        }

        public async Task<Guid> UpdateBook(Book book)
        {
            Update(book);
            await Commit();

            return book.Id;
        }

        public async Task RemoveBooks(IEnumerable<Book> books)
        {
            RemoveRange(books);
            await Commit();
        }

        public async Task RemoveBook(Book book)
        {
            Remove(book);
            await Commit();
        }
    }
}
