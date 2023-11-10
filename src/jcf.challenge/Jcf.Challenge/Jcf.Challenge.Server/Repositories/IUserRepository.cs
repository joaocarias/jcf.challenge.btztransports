using Jcf.Challenge.Server.Models;

namespace Jcf.Challenge.Server.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> AnyUserNameAsync(string userName);
    }
}
