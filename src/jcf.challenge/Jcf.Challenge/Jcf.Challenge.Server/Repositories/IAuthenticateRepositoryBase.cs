namespace Jcf.Challenge.Server.Repositories
{
    public interface IAuthenticateRepositoryBase<T> where T : class
    {
        Task<T?> AuthenticateAsync(string username, string password);
        Task<bool> UserNameInUseAsync(string userName);
    }
}
