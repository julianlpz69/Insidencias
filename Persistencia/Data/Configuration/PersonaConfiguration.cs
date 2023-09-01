using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder){
        
            builder.ToTable("persona");

            builder.Property(e => e.Nombre)
                .HasMaxLength(50);

            builder.Property(e => e.Apellido)
                .HasMaxLength(50);


            builder.HasOne(p => p.Ciudad)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCiudadFK); 


            builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoPersonaFk);


            builder.HasOne(p => p.TipoGenero)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoGeneroFK);
        
        }
    }
}