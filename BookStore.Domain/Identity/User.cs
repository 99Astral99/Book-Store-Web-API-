using Microsoft.AspNetCore.Identity;

namespace BookStore.Domain.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
