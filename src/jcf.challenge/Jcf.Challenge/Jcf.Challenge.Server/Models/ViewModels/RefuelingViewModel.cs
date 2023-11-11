using Jcf.Challenge.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Challenge.Server.Models.ViewModels
{
    public record RefuelingViewModel
    (
        Guid? Id,   
        [Required] Guid VehicleId,
        [Required] Guid DriverId,
        [Required] DateTime DateRefueling,
        [Required] EFuelType FuelType,
        [Required] double Quantity
    );
}
