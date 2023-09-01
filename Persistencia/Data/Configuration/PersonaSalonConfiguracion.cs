using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaSalonConfiguracion : IEntityTypeConfiguration<PersonaSalon>
    {
        public void Configure(EntityTypeBuilder<PersonaSalon> builder){
        
            builder.ToTable("personaSalon");

           builder.HasOne(p => p.Persona)
            .WithMany(p => p.PersonasSalones)
            .HasForeignKey(p => p.IdPersonaFK);

            builder.HasOne(p => p.Salon)
            .WithMany(p => p.PersonasSalones)
            .HasForeignKey(p => p.IdSalonFk);
        }
    }
}