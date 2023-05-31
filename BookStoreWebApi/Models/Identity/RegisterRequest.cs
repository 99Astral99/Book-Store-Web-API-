using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApi.Models.Identity
{

    public class RegisterRequest
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

		[Required]
		[Display(Name = "User name")]
		public string UserName { get; set; } = null!;

		[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; } = null!;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
    }
}

