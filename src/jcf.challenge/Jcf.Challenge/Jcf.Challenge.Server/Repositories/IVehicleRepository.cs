using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Server.Repositories
{
    public interface IVehicleRepository : IRepositoryBase<Vehicle>
    {
        Task<IEnumerable<Vehicle>> ListAllAsync();

        Task<bool> PlateInUse(string plate);
    }
}
