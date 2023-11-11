using Jcf.Challenge.Server.Enums;
using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Jcf.Challenge.Server.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(e =>
            {
                e.Property(x => x.LicenseCategories).HasColumnType("VARCHAR(50)").HasConversion(
                    x => JsonConvert.SerializeObject(x),
                    x => JsonConvert.DeserializeObject<List<EDriversLicenseCategory>>(x)
                );
            });
        }
    }
}
