using Jcf.Challenge.Server.Data.Contexts;
using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Challenge.Server.Repositories
{
    public class RefuelingRepository : IRefuelingRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<RefuelingRepository> _logger;

        public RefuelingRepository(AppDbContext appDbContext, ILogger<RefuelingRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Refueling?> CreateAsync(Refueling entity)
        {
            try
            {
                await _appDbContext.Refuelings.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public bool Delete(Refueling entity)
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

        public async Task<Refueling?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _appDbContext.Refuelings.AsNoTracking().SingleOrDefaultAsync(_ => _.Id.Equals(id) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Refueling>> ListAllAsync()
        {
            try
            {
                return await _appDbContext.Refuelings
                                .Include(x => x.Driver).AsNoTracking()
                                .Include(x => x.Vehicle).AsNoTracking()
                                .AsNoTracking()
                                .Where(_ => _.IsActive)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Refueling>();
            }
        }

        public Refueling? Update(Refueling entity)
        {
            try
            {
                _appDbContext.Refuelings.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }     
    }
}
