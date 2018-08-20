namespace briefCore.Data.Contexts
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Library.Entities;
    using Maps;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
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
            new BookMap(modelBuilder.Entity<Book>());
            new SeriesMap(modelBuilder.Entity<Series>());
            new EditionMap(modelBuilder.Entity<Edition>());
            new LocationMap(modelBuilder.Entity<Location>());
            new AuthorMap(modelBuilder.Entity<Author>());
            new CoverMap(modelBuilder.Entity<Cover>());
            new EditionFileMap(modelBuilder.Entity<EditionFile>());
            new BookInSeriesMap(modelBuilder.Entity<BookInSeries>());
            new BookByAuthorMap(modelBuilder.Entity<BookByAuthor>());
            new PublisherMap(modelBuilder.Entity<Publisher>());
            new DeviceMap(modelBuilder.Entity<Device>());
            new UserDeviceMap(modelBuilder.Entity<UserDevice>());
            new ImportInfoMap(modelBuilder.Entity<ImportInfo>());
            new WhishlistMap(modelBuilder.Entity<Whishlist>());
            new UnfinishedListMap(modelBuilder.Entity<UnfinishedList>());
            new GenreMap(modelBuilder.Entity<Genre>());
            new BookInGenreMap(modelBuilder.Entity<BookInGenre>());
            new EditionInUnfinishedListMap(modelBuilder.Entity<EditionInUnfinishedList>());
            new EditionInWhishlistMap(modelBuilder.Entity<EditionInWhishlist>());
            
            base.OnModelCreating(modelBuilder);
        }

        public Task<int> Commit()
            => SaveChangesAsync();
    }
}