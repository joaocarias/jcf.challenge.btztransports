using Jcf.Challenge.Server.Data.Contexts;
using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Challenge.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<bool> UserNameInUseAsync(string userName)
        {
            try
            {
                return await _appDbContext.Users.AsNoTracking().AnyAsync(_ => _.UserName.Equals(userName));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<User?> CreateAsync(User entity)
        {
            try
            {
                await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public bool Delete(User entity)
        {
            try
            {
                entity.Remove();                
                return Update(entity) is not null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _appDbContext.Users.AsNoTracking().SingleOrDefaultAsync(_ => _.Id.Equals(id) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public User? Update(User entity)
        {
            try
            {
                _appDbContext.Users.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                var c = await _appDbContext.Users
                                .AsNoTracking()
                                .SingleOrDefaultAsync(_ => _.IsActive.Equals(true) && _.UserName.Equals(userName) && _.Password.Equals(password));
                return c;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
