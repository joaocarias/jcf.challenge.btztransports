using Jcf.Challenge.Server.Enums;

namespace Jcf.Challenge.Server.Models.ViewModels
{
    public record CreateVehicleViewModel
    (
        string Name,
        string Plate,
        EFuelType FuelType,
        string Manufacturer,
        int YearManufacture,
        double MaxCapacityFuel,
        string? Observation
    );
}
