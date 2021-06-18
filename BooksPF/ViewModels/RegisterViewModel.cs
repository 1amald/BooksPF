using System.ComponentModel.DataAnnotations;

namespace BooksPF.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [LoginValidation]
        public string Login { get; set; }
        [Required]
        [PasswordValidation]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
