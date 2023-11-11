using Jcf.Challenge.Server.Enums;

namespace Jcf.Challenge.Server.Extensions.Helpers
{
    public static class RefuelingHelper
    {
        // RN1 - o sistema deve validar se a quantidade abastecida é menor que a capacidade do tanque do veículo
        public static bool QuantityRefueledIsValidate(double quantityRefueled, double tankCapacity)
        {
            try
            {
                return quantityRefueled <= tankCapacity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // RN2 - o sistema deve validar se o combustível informado no abastecimento pode ser usado para aquele veículo(consultar cadastro de veículo)
        public static bool FuelIsValidade(EFuelType fuelRefueled, EFuelType fuelVehicle)
        {
            try
            {
                return fuelRefueled.Equals(fuelVehicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // RN3 - o sistema deve realizar o cálculo do total do abastecimento após a validação e salvar estas informações no banco de dados.
        public static double GetPaidAmount(double quantityRefueled, EFuelType eFuelType)
        {
            try
            {
                var

                return quantityRefueled *
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
    }
}
