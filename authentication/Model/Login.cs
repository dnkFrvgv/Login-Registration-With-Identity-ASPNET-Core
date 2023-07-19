using System.ComponentModel.DataAnnotations;

namespace authentication.Model
{
  public class Login
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The password must be between 6 and 8 characters.")]
        public string Password { get; set; }
    }
}