using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Server.Repositories
{
    public interface IReportRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> ListAllAsync();
    }
}
