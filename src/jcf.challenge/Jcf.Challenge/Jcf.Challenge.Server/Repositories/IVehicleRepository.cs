using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Server.Repositories
{
    public interface IVehicleRepository : IRepositoryBase<Vehicle>, IReportRepositoryBase<Vehicle>
    {
        Task<bool> PlateInUse(string plate);
    }
}
