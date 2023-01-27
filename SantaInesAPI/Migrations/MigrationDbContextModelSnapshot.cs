﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantaInesAPI.Persistence.Database;

#nullable disable

namespace SantaInesAPI.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    partial class MigrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Cita", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("doctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("fecha_hora")
                        .HasColumnType("datetime2");

                    b.Property<string>("paciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("doctor");

                    b.HasIndex("paciente");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Departamento", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Direccion", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("cod_postal")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Empleado", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("apellido_completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cedula")
                        .HasColumnType("int");

                    b.Property<Guid>("id_departamento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("id_itinerario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombre_completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.HasIndex("id_departamento");

                    b.HasIndex("id_itinerario")
                        .IsUnique()
                        .HasFilter("[id_itinerario] IS NOT NULL");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Itinerario", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("hora_fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("hora_inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Itinerarios");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Usuario", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("apellido_completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cedula")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("id_direccion")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombre_completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.HasIndex("id_direccion")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Cita", b =>
                {
                    b.HasOne("SantaInesAPI.Persistence.Entity.Empleado", "Empleado")
                        .WithMany("Citas")
                        .HasForeignKey("doctor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SantaInesAPI.Persistence.Entity.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("paciente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Empleado", b =>
                {
                    b.HasOne("SantaInesAPI.Persistence.Entity.Departamento", "Departamento")
                        .WithMany("Empleados")
                        .HasForeignKey("id_departamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SantaInesAPI.Persistence.Entity.Itinerario", "Itinerario")
                        .WithOne("Empleado")
                        .HasForeignKey("SantaInesAPI.Persistence.Entity.Empleado", "id_itinerario");

                    b.Navigation("Departamento");

                    b.Navigation("Itinerario");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Usuario", b =>
                {
                    b.HasOne("SantaInesAPI.Persistence.Entity.Direccion", "Direccion")
                        .WithOne("Usuario")
                        .HasForeignKey("SantaInesAPI.Persistence.Entity.Usuario", "id_direccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Departamento", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Direccion", b =>
                {
                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Empleado", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Itinerario", b =>
                {
                    b.Navigation("Empleado")
                        .IsRequired();
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Usuario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
