using BookStore.Domain.Identity;
using BookStoreWebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace BookStoreWebApi.Services.Identity
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string CreateToken(User user, List<IdentityRole<Guid>> roles)
		{
			var token = user
				.CreateClaims(roles)
				.CreateJwtToken(_configuration);
			var tokenHandler = new JwtSecurityTokenHandler();

			return tokenHandler.WriteToken(token);
		}
	}
}
