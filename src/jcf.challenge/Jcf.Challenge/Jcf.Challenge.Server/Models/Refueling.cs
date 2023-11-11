using Jcf.Challenge.Server.Enums;

namespace Jcf.Challenge.Server.Models
{
    public class Refueling : EntityBase
    {
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }    

        public Guid DriverId { get; set; }  
        public Driver Driver { get; set; }  

        public DateTime DateRefueling { get; set; }

        public EFuelType FuelType { get; set; }

        public double Quantity { get; set; }

        public Refueling(Guid vehicleId, Guid driverId, DateTime dateRefueling, EFuelType fuelType, double quantity, Guid? userCreateId = null)
            :base (userCreateId)
        {
            VehicleId = vehicleId;            
            DriverId = driverId;
            DateRefueling = dateRefueling;
            FuelType = fuelType;
            Quantity = quantity;
        }

        public void Update(Guid vehicleId, Guid driverId, DateTime dateRefueling, EFuelType fuelType, double quantity, Guid? userUpdateId = null)
        {
            VehicleId = vehicleId;
            DriverId = driverId;
            DateRefueling = dateRefueling;
            FuelType = fuelType;
            Quantity = quantity;

            UpdatedAt = DateTime.UtcNow;
            UserUpdateId = userUpdateId;
        }
    }
}
