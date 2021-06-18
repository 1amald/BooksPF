using System.ComponentModel.DataAnnotations;

namespace BooksPF.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [LoginValidation]
        public string Login { get; set; }
        [Required]
        [PasswordValidation]
        public string Password { get; set; }
    }
}
