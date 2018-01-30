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
            
            //Database.SetInitializer(
            //    new CreateDatabaseIfNotExists<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(null);
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
                
            base.OnModelCreating(modelBuilder);
        }

        public Task<int> Commit()
            => SaveChangesAsync();
    }
}