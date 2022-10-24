using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;


namespace SantaInesAPI.Persistence.Database
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
    }
}