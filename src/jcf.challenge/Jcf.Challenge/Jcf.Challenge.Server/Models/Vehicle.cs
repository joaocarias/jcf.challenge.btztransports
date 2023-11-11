using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models
{
    public class Vehicle : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Plate { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


    }
}
