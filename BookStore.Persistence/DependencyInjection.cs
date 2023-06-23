using BookStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(
			this IServiceCollection services,
			IConfiguration configuration)
		{

			var dbHost = Environment.GetEnvironmentVariable("POSTGRES_HOST");
			var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
			var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
			var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
			var connectionString = $"Host={dbHost};User Id={dbUser};Password={dbPassword};Port=5432;Database={dbName}";
			//local connection string:
			//var connectionString = "Host = localhost; Port = 5432; Database = BookStoreDb; Username = postgres; Password = master";

			services.AddDbContext<BookStoreDbContext>(options =>
			{
				options.UseNpgsql(connectionString, m =>
				m.MigrationsAssembly("BookStore.Persistence"));
			});

			services.AddScoped<IBookStoreDbContext>(provider =>
				provider.GetService<BookStoreDbContext>());

			return services;
		}
	}
}