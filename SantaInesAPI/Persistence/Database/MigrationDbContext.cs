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

            modelBuilder.Entity<Empleado>()
            .HasOne(b => b.Departamento)
            .WithMany(i => i.Empleados)
            .HasForeignKey(b => b.id_departamento);

            modelBuilder.Entity<Cita>()
            .HasOne(b => b.Usuario)
            .WithMany(i => i.Citas)
            .HasForeignKey(b => b.paciente);

            modelBuilder.Entity<Cita>()
            .HasOne(b => b.Empleado)
            .WithMany(i => i.Citas)
            .HasForeignKey(b => b.doctor);

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}