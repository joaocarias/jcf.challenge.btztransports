using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Server.Repositories
{
    public interface IDriverRepository : IRepositoryBase<Driver>
    {
        Task<IEnumerable<Driver>> ListAll();
    }
}
