using Jcf.Challenge.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Challenge.Server.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
