using Jcf.Challenge.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models
{
    public class Refueling : EntityBase
    {
        [Required]
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [Required]
        public Guid DriverId { get; set; }  
        public Driver Driver { get; set; }

        [Required]
        public DateTime DateRefueling { get; set; }

        [Required]
        public EFuelType FuelType { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public double PaidAmount { get; set; } = 0;

        public Refueling(Guid vehicleId, Guid driverId, DateTime dateRefueling, EFuelType fuelType, double quantity, Guid? userCreateId = null)
            : base(userCreateId)
        {
            VehicleId = vehicleId;
            DriverId = driverId;
            DateRefueling = dateRefueling;
            FuelType = fuelType;
            Quantity = quantity;
        }

        public Refueling(Guid vehicleId, Guid driverId, DateTime dateRefueling, EFuelType fuelType, double quantity, double paidAmount, Guid? userCreateId = null)
            :base (userCreateId)
        {
            VehicleId = vehicleId;            
            DriverId = driverId;
            DateRefueling = dateRefueling;
            FuelType = fuelType;
            Quantity = quantity;
            PaidAmount = paidAmount;
        }

        public void Update(Guid vehicleId, Guid driverId, DateTime dateRefueling, EFuelType fuelType, double quantity, double paidAmount, Guid? userUpdateId = null)
        {
            VehicleId = vehicleId;
            DriverId = driverId;
            DateRefueling = dateRefueling;
            FuelType = fuelType;
            Quantity = quantity;
            PaidAmount = paidAmount;

            UpdatedAt = DateTime.UtcNow;
            UserUpdateId = userUpdateId;
        }
    }
}
