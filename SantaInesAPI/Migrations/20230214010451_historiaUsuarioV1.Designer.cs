﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantaInesAPI.Persistence.Database;

#nullable disable

namespace SantaInesAPI.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20230214010451_historiaUsuarioV1")]
    partial class historiaUsuarioV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctor")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("patient")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("doctor");

                    b.HasIndex("patient");

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

                    b.Property<Guid?>("id_departamento")
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

                    b.Property<string>("sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.HasIndex("id_departamento");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.HistoriaMedica", b =>
                {
                    b.Property<Guid>("idHistoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("alergias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("altura")
                        .HasColumnType("real");

                    b.Property<string>("andtFamiliares")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("antPeronales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("intQuirurgica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("patologia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("peso")
                        .HasColumnType("real");

                    b.Property<string>("tipoSangre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tratHabitual")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idHistoria");

                    b.ToTable("HistoriaMedicas");
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

                    b.Property<Guid>("idHistoria")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasIndex("idHistoria")
                        .IsUnique();

                    b.HasIndex("id_direccion")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Cita", b =>
                {
                    b.HasOne("SantaInesAPI.Persistence.Entity.Empleado", "Empleado")
                        .WithMany("Citas")
                        .HasForeignKey("doctor");

                    b.HasOne("SantaInesAPI.Persistence.Entity.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("patient");

                    b.Navigation("Empleado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Empleado", b =>
                {
                    b.HasOne("SantaInesAPI.Persistence.Entity.Departamento", "Departamento")
                        .WithMany("Empleados")
                        .HasForeignKey("id_departamento");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.Usuario", b =>
                {
                    b.HasOne("SantaInesAPI.Persistence.Entity.HistoriaMedica", "HistoriaMedica")
                        .WithOne("Usuario")
                        .HasForeignKey("SantaInesAPI.Persistence.Entity.Usuario", "idHistoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SantaInesAPI.Persistence.Entity.Direccion", "Direccion")
                        .WithOne("Usuario")
                        .HasForeignKey("SantaInesAPI.Persistence.Entity.Usuario", "id_direccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");

                    b.Navigation("HistoriaMedica");
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

            modelBuilder.Entity("SantaInesAPI.Persistence.Entity.HistoriaMedica", b =>
                {
                    b.Navigation("Usuario")
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
