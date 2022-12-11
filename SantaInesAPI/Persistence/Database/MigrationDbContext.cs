using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using SantaInesAPI.Persistence.Database;
using SantaInesAPI.Persistence.Entity;
using System.Reflection.Metadata;


namespace SantaInesAPI.Persistence.Database
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direccion>()
            .HasOne(b => b.Usuario)
            .WithOne(i => i.Direccion)
            .HasForeignKey<Usuario>(b => b.id_direccion);
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}