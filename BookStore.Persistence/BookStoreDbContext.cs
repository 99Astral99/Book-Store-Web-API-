using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());

            builder.Entity<Book>().HasData(
                new
                {
                    Id = 1,
                    Title = "The First World War: A Complete History",
                    Genre = "History",
                    Author = "Martin Gilbert",
                    Price = 25.55m,
                    Amount = 30,
                    CreationYear = "2004"
                });

            builder.Entity<Book>().HasData(
                new
                {
                    Id = 2,
                    Title = "The Republic",
                    Genre = "Philosophy",
                    Author = "Plato",
                    Price = 5m,
                    Amount = 100,
                    CreationYear = "2021"
                });

            builder.Entity<Book>().HasData(
                new
                {
                    Id = 3,
                    Title = "ASP.NET Core in Action, Second Edition",
                    Genre = "Programming",
                    Author = "Andrew Lock",
                    Price = 36.39m,
                    Amount = 45,
                    CreationYear = "2021"
                });

            builder.Entity<Book>().HasData(
                new
                {
                    Id = 4,
                    Title = "Meditations",
                    Genre = "Philosophy",
                    Author = "Marcus Aurelius",
                    Price = 12.83m,
                    Amount = 115,
                    CreationYear = "2018"
                });


            base.OnModelCreating(builder);
        }
    }
}
