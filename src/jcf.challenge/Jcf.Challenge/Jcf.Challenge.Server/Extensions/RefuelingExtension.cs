using Jcf.Challenge.Server.Extensions.Helpers;
using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Server.Extensions
{
    public static class RefuelingExtension
    {

        // RN1 - o sistema deve validar se a quantidade abastecida é menor que a capacidade do tanque do veículo
        public static bool QuantityRefueledIsValidate(this Refueling refueling, Vehicle vehicle)
        {
            try
            {
                var x = refueling.Quantity <= vehicle.MaxCapacityFuel;
                return x;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // RN2 - o sistema deve validar se o combustível informado no abastecimento pode ser usado para aquele veículo(consultar cadastro de veículo)
        public static bool FuelIsValidade(this Refueling refueling, Vehicle vehicle)
        {
            try
            {
                var t = refueling.FuelType.Equals(vehicle.FuelType);
                return t;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // RN3 - o sistema deve realizar o cálculo do total do abastecimento após a validação e salvar estas informações no banco de dados.
        public static double GetPaidAmount(this Refueling refueling)
        {
            try
            {
                double? valueDefault = double.Parse(ConfigurationHelper.GetConfiguration($"FuelTypes:{refueling.FuelType.ToString()}:Value"));
                var paid = valueDefault is null ? -1 : refueling.Quantity * valueDefault.GetValueOrDefault();
                return paid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
    }
}
