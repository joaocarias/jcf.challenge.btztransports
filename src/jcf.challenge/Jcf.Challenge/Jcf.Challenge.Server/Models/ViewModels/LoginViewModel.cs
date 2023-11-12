using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public LoginViewModel()
        {

        }

        public LoginViewModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
