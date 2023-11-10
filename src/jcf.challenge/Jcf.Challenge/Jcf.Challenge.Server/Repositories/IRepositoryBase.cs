namespace Jcf.Challenge.Server.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T>? GetById(int id);        
        T? Update(T entity);
        Task Delete(T entity);
        Task<T> Create(T entity);
    }
}
