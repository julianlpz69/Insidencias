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

        modelBuilder.Entity<PersonaSalon>().HasKey(ps => new { ps.IdPersonaFK, ps.IdSalonFk });
            
        }
    }
}