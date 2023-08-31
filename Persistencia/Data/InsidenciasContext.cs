using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class IncidenciasContext : DbContext
    {
        public IncidenciasContext(DbContextOptions<IncidenciasContext> options) : base(options)
        {
            
        }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Departamento> Departamentos{ get; set; }
        public DbSet<Matricula> Matriculas{ get; set; }
        public DbSet<Pais> Paises{ get; set; }
        public DbSet<Persona> Personas{ get; set; }
        public DbSet<PersonaSalon> PersonasSalones{ get; set; }
        public DbSet<Salon> Salones{ get; set; }
        public DbSet<TipoGenero> TiposGeneros{ get; set; }
        public DbSet<TipoPersona> TiposPersonas{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Persona>() 
            .HasMany<Matricula>(g => g.Matriculas) 
            .WithOne(s => s.Persona) 
            .HasForeignKey(s => s.IdPersonaFK);  


        modelBuilder.Entity<Pais>() 
            .HasMany<Departamento>(g => g.Departamentos) 
            .WithOne(s => s.Pais) 
            .HasForeignKey(s => s.IdPaisFk);   


        modelBuilder.Entity<Departamento>() 
            .HasMany<Ciudad>(g => g.Ciudades) 
            .WithOne(s => s.Departamento) 
            .HasForeignKey(s => s.IdDepartamentoFK);   


        modelBuilder.Entity<TipoPersona>() 
            .HasMany<Persona>(g => g.Personas) 
            .WithOne(s => s.TipoPersona) 
            .HasForeignKey(s => s.IdTipoPersonaFk); 


        modelBuilder.Entity<TipoGenero>() 
            .HasMany<Persona>(g => g.Personas) 
            .WithOne(s => s.TipoGenero) 
            .HasForeignKey(s => s.IdTipoGeneroFK);  


        modelBuilder.Entity<Salon>() 
            .HasMany<Matricula>(g => g.Matriculas) 
            .WithOne(s => s.Salon) 
            .HasForeignKey(s => s.IdSalonFk);              


        modelBuilder.Entity<PersonaSalon> ( ).HasKey(sc => new { sc.IdPersonaFK, sc.IdSalonFk });

        modelBuilder.Entity<PersonaSalon> ( )
            .HasOne< Persona >(sc => sc.Persona)
            .WithMany(s => s.PersonasSalones)
            .HasForeignKey(sc => sc.IdPersonaFK);

        modelBuilder.Entity<PersonaSalon> ( )
            .HasOne<Salon>(sc => sc.Salon)
            .WithMany(s => s.PersonasSalones)
            .HasForeignKey(sc => sc.IdSalonFk);

        }
    }
}