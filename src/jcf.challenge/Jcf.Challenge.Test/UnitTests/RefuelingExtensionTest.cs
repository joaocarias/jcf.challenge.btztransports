using Jcf.Challenge.Server.Enums;
using Jcf.Challenge.Server.Extensions;
using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Test.UnitTests
{
    public class RefuelingExtensionTest
    {
        [Theory]
        [InlineData(EFuelType.Gasoline, EFuelType.Diesel)]
        [InlineData(EFuelType.Gasoline, EFuelType.Ethanol)]
        [InlineData(EFuelType.Diesel, EFuelType.Ethanol)]
        [InlineData(EFuelType.Diesel, EFuelType.Gasoline)]
        [InlineData(EFuelType.Ethanol, EFuelType.Gasoline)]
        [InlineData(EFuelType.Ethanol, EFuelType.Diesel)]
        public void FuelIsValidade_Distincts_ReturnTrue(EFuelType r, EFuelType v)
        {
            var Refueling = new Refueling(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, r, 100, Guid.NewGuid());
            var vehicle = new Vehicle("RGN2021", "Test", v, "Test", 2000, 200, null, Guid.NewGuid());

            Assert.False(Refueling.FuelIsValidade(vehicle));
        }

        [Theory]
        [InlineData(EFuelType.Gasoline, EFuelType.Gasoline)]        
        [InlineData(EFuelType.Diesel, EFuelType.Diesel)]        
        [InlineData(EFuelType.Ethanol, EFuelType.Ethanol)]        
        public void FuelIsValidade_Not_Distincts_ReturnFalse(EFuelType r, EFuelType v)
        {
            var Refueling = new Refueling(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, r, 100, Guid.NewGuid());
            var vehicle = new Vehicle("RGN2021", "Test", v, "Test", 2000, 200, null, Guid.NewGuid());

            Assert.True(Refueling.FuelIsValidade(vehicle));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(10)]
        [InlineData(20)]
        public void QuantityRefueledIsValidate_ReturnTrue(double quantity)
        {
            var Refueling = new Refueling(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, EFuelType.Gasoline, quantity, Guid.NewGuid());
            var vehicle = new Vehicle("RGN2021", "Test", EFuelType.Gasoline, "Test", 2000, 200, null, Guid.NewGuid());

            Assert.True(Refueling.QuantityRefueledIsValidate(vehicle));
        }

        [Theory]
        [InlineData(201)]
        [InlineData(1000)]
        [InlineData(254)]
        public void QuantityRefueledIsValidate_ReturnFalse(double quantity)
        {
            var Refueling = new Refueling(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, EFuelType.Gasoline, quantity, Guid.NewGuid());
            var vehicle = new Vehicle("RGN2021", "Test", EFuelType.Gasoline, "Test", 2000, 200, null, Guid.NewGuid());

            Assert.False(Refueling.QuantityRefueledIsValidate(vehicle));
        }

        [Theory]
        [InlineData(20.00)]
        [InlineData(100.10)]
        [InlineData(54.30)]
        public void GetPaidAmount_ReturnTrue(double quantity)
        {
            var Refueling = new Refueling(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, EFuelType.Diesel, quantity, Guid.NewGuid());           

            Assert.False(Refueling.GetPaidAmount() > 0);
        }

    }
}
