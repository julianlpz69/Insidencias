using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoGeneroConfiguration : IEntityTypeConfiguration<TipoGenero>
    {
        public void Configure(EntityTypeBuilder<TipoGenero> builder){
        
            builder.ToTable("tipoGenero");

            builder.Property(e => e.NombreGenero)
                .HasMaxLength(50);
        
        }
    }
}