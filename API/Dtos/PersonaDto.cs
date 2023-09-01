using Dominio.Entities;

namespace API.Dtos
{
    public class PersonaDto : BaseEntity
    {
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Dirrecion {get; set;}

    }
}