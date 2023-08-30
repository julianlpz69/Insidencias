using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder){
        
            builder.ToTable("ciudad");

            builder.Property(e => e.NombreCiudad)
                .HasMaxLength(30);
        
        }
    }
}