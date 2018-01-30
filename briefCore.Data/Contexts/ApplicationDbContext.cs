namespace briefCore.Data.Contexts
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Library.Entities;
    using Maps;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        
        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);    
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SeriesMap(modelBuilder.Entity<Series>());
            new EditionMap(modelBuilder.Entity<Edition>());
            new LocationMap(modelBuilder.Entity<Location>());
            new AuthorMap(modelBuilder.Entity<Author>());
            new CoverMap(modelBuilder.Entity<Cover>());
            new EditionFileMap(modelBuilder.Entity<EditionFile>());
            new BookInSeriesMap(modelBuilder.Entity<BookInSeries>());
            new BookByAuthorMap(modelBuilder.Entity<BookByAuthor>());
                
            base.OnModelCreating(modelBuilder);
        }

        public Task<int> Commit()
            => SaveChangesAsync();
    }
}