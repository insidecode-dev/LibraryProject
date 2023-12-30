using LibraryProject.Configurations;
using LibraryProject.Initializer;
using LibraryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {}

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books > Books { get; set; }
        public DbSet<BookTypes> BookTypes { get; set; } 
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Operations
            modelBuilder.ApplyConfiguration(new OperationConfiguration());

            //Authors
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            //Students
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            //StudentDetail
            modelBuilder.ApplyConfiguration(new StudentDetailConfiguration());

            //Seed Data
            DataInitializer.Seed(modelBuilder);
        }
    }
}
