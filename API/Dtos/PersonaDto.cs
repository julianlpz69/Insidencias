using Dominio.Entities;

namespace API.Dtos
{
    public class PersonaDto 
    {
        public int Id { get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Dirrecion {get; set;}
        public int IdTipoPersonaFk {get; set;}
        public int IdCiudadFK {get; set;}
        public int IdTipoGeneroFK {get; set;}

    }
}