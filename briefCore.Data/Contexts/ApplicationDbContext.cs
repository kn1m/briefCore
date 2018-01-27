namespace briefCore.Data.Contexts
{
    using System.Threading.Tasks;
    using Interfaces;
    using Library.Entities;
    using Maps;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(
            //    new CreateDatabaseIfNotExists<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SeriesMap(modelBuilder.Entity<Series>());
            new LocationMap(modelBuilder.Entity<Location>());
            
            base.OnModelCreating(modelBuilder);
        }

        public Task<int> Commit()
            => SaveChangesAsync();
    }
}