using Jcf.Challenge.Server.Data.Contexts;
using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Challenge.Server.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<VehicleRepository> _logger;

        public VehicleRepository(AppDbContext appDbContext, ILogger<VehicleRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Vehicle?> CreateAsync(Vehicle entity)
        {
            try
            {
                await _appDbContext.Vehicles.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public bool Delete(Vehicle entity)
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

        public async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _appDbContext.Vehicles.AsNoTracking().SingleOrDefaultAsync(_ => _.Id.Equals(id) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Vehicle>> ListAllAsync()
        {
            try
            {
                return await _appDbContext.Vehicles.AsNoTracking().Where(_ => _.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Vehicle>();
            }
        }

        public async Task<bool> PlateInUse(string plate)
        {
            try
            {
                return await _appDbContext.Vehicles.AsNoTracking().AnyAsync(_ => _.Plate.Equals(plate) && _.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public Vehicle? Update(Vehicle entity)
        {
            try
            {
                _appDbContext.Vehicles.Update(entity);
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
