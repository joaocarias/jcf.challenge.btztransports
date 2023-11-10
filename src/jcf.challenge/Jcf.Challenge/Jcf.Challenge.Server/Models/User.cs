using Jcf.Challenge.Server.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Challenge.Server.Models
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [NotMapped]
        public string FirstName { get { return Name.FirstPart(); } }

        public User(string name, string email, string userName, string password) : base()
        {
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
        }

        public void ClearPassword()
        {
            Password = "";
        }
    }
}
