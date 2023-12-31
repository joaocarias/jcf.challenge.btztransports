﻿namespace Jcf.Challenge.Server.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);        
        T? Update(T entity);
        bool Delete(T entity);
        Task<T?> CreateAsync(T entity);
    }
}
