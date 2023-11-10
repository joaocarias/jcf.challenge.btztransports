using Jcf.Challenge.Server.Data.Contexts;
using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Challenge.Server.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<DriverRepository> _logger;

        public DriverRepository(AppDbContext appDbContext, ILogger<DriverRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Driver?> CreateAsync(Driver entity)
        {
            try
            {
                await _appDbContext.Drivers.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public bool Delete(Driver entity)
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

        public async Task<bool> DocumentNumberInUse(string documentNumber)
        {
            try
            {
                return await _appDbContext.Drivers.AsNoTracking().AnyAsync(_ => _.DocumentNumber.Equals(documentNumber) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Driver?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _appDbContext.Drivers.AsNoTracking().SingleOrDefaultAsync(_ => _.Id.Equals(id) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> LicenseNumberInUse(string licenseNumber)
        {
            try
            {
                return await _appDbContext.Drivers.AsNoTracking().AnyAsync(_ => _.LicenseNumber.Equals(licenseNumber) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Driver>> ListAll()
        {
            try
            {
                return await _appDbContext.Drivers.AsNoTracking().Where(_ => _.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Driver>();
            }
        }

        public Driver? Update(Driver entity)
        {
            try
            {
                _appDbContext.Drivers.Update(entity);
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
