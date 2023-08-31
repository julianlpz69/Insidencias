﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Data;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(IncidenciasContext))]
    [Migration("20230831012931_SegundaMigracion")]
    partial class SegundaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamentoFK")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamentoFK");

                    b.ToTable("ciudad", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreDepartamento")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("IdPaisFk");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPersonaFK")
                        .HasColumnType("int");

                    b.Property<int>("IdSalonFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPersonaFK");

                    b.HasIndex("IdSalonFk");

                    b.ToTable("matricula", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("Dirrecion")
                        .HasColumnType("longtext");

                    b.Property<int>("IdCiudadFK")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoGeneroFK")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersonaFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("IdTipoGeneroFK");

                    b.HasIndex("IdTipoPersonaFk");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.PersonaSalon", b =>
                {
                    b.Property<int>("IdPersonaFK")
                        .HasColumnType("int");

                    b.Property<int>("IdSalonFk")
                        .HasColumnType("int");

                    b.HasKey("IdPersonaFK", "IdSalonFk");

                    b.HasIndex("IdSalonFk");

                    b.ToTable("PersonasSalones");
                });

            modelBuilder.Entity("Dominio.Entities.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("NombreSalon")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("salon", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoGenero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreGenero")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tipoGenero", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tipoPersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamentoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("Dominio.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Dominio.Entities.Matricula", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdPersonaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Salon", "Salon")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdSalonFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.Ciudad", "Ciudad")
                        .WithMany("Personas")
                        .HasForeignKey("CiudadId");

                    b.HasOne("Dominio.Entities.TipoGenero", "TipoGenero")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoGeneroFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("TipoGenero");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Dominio.Entities.PersonaSalon", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Persona")
                        .WithMany("PersonasSalones")
                        .HasForeignKey("IdPersonaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Salon", "Salon")
                        .WithMany("PersonasSalones")
                        .HasForeignKey("IdSalonFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("PersonasSalones");
                });

            modelBuilder.Entity("Dominio.Entities.Salon", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("PersonasSalones");
                });

            modelBuilder.Entity("Dominio.Entities.TipoGenero", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}