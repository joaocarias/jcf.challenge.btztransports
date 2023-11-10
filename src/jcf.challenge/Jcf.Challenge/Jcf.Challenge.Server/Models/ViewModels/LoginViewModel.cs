using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public LoginViewModel()
        {

        }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
