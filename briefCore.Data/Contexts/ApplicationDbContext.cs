﻿namespace briefCore.Data.Contexts
{
    using System.Reflection;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(
            //    new CreateDatabaseIfNotExists<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> Commit()
            => SaveChangesAsync();
    }
}