using Jcf.Challenge.Server.Enums;
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

        [Required]
        public EFuelType FuelType { get; set; }

        [Required]
        [StringLength(255)]
        public string Manufacturer { get; set; }

        [Required]
        public int YearManufacture { get; set; }

        [Required]
        public double MaxCapacityFuel { get; set; }

        [StringLength(255)]
        public string? Observation { get; set; }

        public Vehicle(string plate, string name, EFuelType fuelType, string manufacturer, int yearManufacture, double maxCapacityFuel, string? observation, Guid? userCreateId = null)
            : base(userCreateId)
        {
            Plate = plate;
            Name = name;
            FuelType = fuelType;
            Manufacturer = manufacturer;
            YearManufacture = yearManufacture;
            MaxCapacityFuel = maxCapacityFuel;
            Observation = observation;
        }

        public void Update(string plate, string name, EFuelType fuelType, string manufacturer, int yearManufacture, double maxCapacityFuel, string? observation, Guid? userUpdateId = null)
        {
            Plate = plate;
            Name = name;
            FuelType = fuelType;
            Manufacturer = manufacturer;
            YearManufacture = yearManufacture;
            MaxCapacityFuel = maxCapacityFuel;
            Observation = observation;

            UpdatedAt = DateTime.UtcNow;
            UserUpdateId = userUpdateId;
        }
    }
}
