using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Domain.Identity;
using BookStore.Persistence.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence
{
    public class BookStoreDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IBookStoreDbContext
    {
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


            var user1 = new User()
            {
                Id = new Guid("A4A67768-DEDA-43BC-A545-A67D1ABDA650"),
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                FirstName = "Dante",
                LastName = "Sparda",
                MiddleName = "Spardovich",
                UserName = "Customer111",
                NormalizedUserName = "CUSTOMER111",
            };

            var user2 = new User()
            {
                Id = new Guid("12539B7B-B1E6-4A04-BE98-6921487CAEF3"),
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                FirstName = "Vergil",
                LastName = "Sparda",
                MiddleName = "Spardovich",
                UserName = "Admin111",
                NormalizedUserName = "ADMIN111",
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            user1.PasswordHash = ph.HashPassword(user1, "DefaultCustomerPassword111");
            user2.PasswordHash = ph.HashPassword(user2, "DefaultAdminPassword111");

            builder.Entity<User>().HasData(user1);
            builder.Entity<User>().HasData(user2);

            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("76BA16A2-158A-46EF-89E7-24E8684AAB20"),
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = "76BA16A2-158A-46EF-89E7-24E8684AAB20"
                });

            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("417EA524-3412-4929-8533-74354E887CC5"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "417EA524-3412-4929-8533-74354E887CC5"
                });


            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("8C11D40A-1D5A-4E4F-9A15-B20A0B045C44"),
                    Name = "Moderator",
                    NormalizedName = "MODERATOR",
                    ConcurrencyStamp = "8C11D40A-1D5A-4E4F-9A15-B20A0B045C44"
                });

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("76BA16A2-158A-46EF-89E7-24E8684AAB20"),
                    UserId = new Guid("A4A67768-DEDA-43BC-A545-A67D1ABDA650")
                });

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("417EA524-3412-4929-8533-74354E887CC5"),
                    UserId = new Guid("12539B7B-B1E6-4A04-BE98-6921487CAEF3")
                });


            base.OnModelCreating(builder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
