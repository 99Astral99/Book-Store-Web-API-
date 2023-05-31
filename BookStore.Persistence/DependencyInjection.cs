using BookStore.Application.Interfaces;
using BookStore.Domain;
using Microsoft.AspNetCore.Identity;
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
			var connectionString = configuration["DbConnection"];
			services.AddDbContext<BookStoreDbContext>(options =>
			{
				options.UseSqlServer(connectionString, m =>
				m.MigrationsAssembly("BookStore.Persistence"));
			});

			services.AddScoped<IBookStoreDbContext>(provider =>
				provider.GetService<BookStoreDbContext>());

			return services;
		}
	}
}
