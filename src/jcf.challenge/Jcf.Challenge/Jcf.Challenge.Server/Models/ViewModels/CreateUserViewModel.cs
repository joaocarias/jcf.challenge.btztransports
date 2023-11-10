using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(16, ErrorMessage = "Inserir de 6 a 16 Caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
