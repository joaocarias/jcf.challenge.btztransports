using Jcf.Challenge.Server.Enums;
using Jcf.Challenge.Server.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Challenge.Server.Models
{
    public class Driver : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        private string _documentNumber { get; set; }

        [Required]
        [StringLength(11)]
        public string DocumentNumber {
            get => _documentNumber;
            set => _documentNumber = value.OnlyNumbers();
        }

        private string _licenseNumber { get; set; }

        [Required]
        [StringLength(11)]
        public string LicenseNumber {
            get => _licenseNumber;
            set => _licenseNumber = value.OnlyNumbers();
        }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public List<EDriversLicenseCategory> LicenseCategories { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]        
        public bool Status { get; set; }

        public Driver(string name, string documentNumber, string licenseNumber, List<EDriversLicenseCategory> licenseCategories, DateTime dateOfBirth, bool status, Guid? userCreateId = null)
            : base (userCreateId)
        {
            Name = name;
            DocumentNumber = documentNumber;            
            LicenseNumber = licenseNumber;            
            LicenseCategories = licenseCategories;
            DateOfBirth = dateOfBirth;
            Status = status;
        }
    }
}
