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
        public EDriversLicenseCategory LicenseCategory { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]        
        public bool Status { get; set; }

        [NotMapped]
        public string FirstName { get { return Name.FirstPart(); } }

        public Driver(string name, string documentNumber, string licenseNumber, EDriversLicenseCategory licenseCategory, DateTime dateOfBirth, bool status, Guid? userCreateId = null)
            : base (userCreateId)
        {
            Name = name;
            DocumentNumber = documentNumber;            
            LicenseNumber = licenseNumber;
            LicenseCategory = licenseCategory;
            DateOfBirth = dateOfBirth;
            Status = status;
        }

        public void Update(string name, string documentNumber, string licenseNumber, EDriversLicenseCategory licenseCategory, DateTime dateOfBirth, bool status, Guid? userUpdateId = null)            
        {
            Name = name;
            DocumentNumber = documentNumber;
            LicenseNumber = licenseNumber;
            LicenseCategory = licenseCategory;
            DateOfBirth = dateOfBirth;
            Status = status;

            UpdatedAt = DateTime.UtcNow;
            UserUpdateId = userUpdateId;
        }
    }
}
