using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Persona : BaseEntity
    {
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Dirrecion {get; set;}
        public int IdTipoPersonaFk {get; set;}
        public TipoPersona TipoPersona {get; set;}
        public int IdCiudadFK {get; set;}
        public Ciudad Ciudad {get; set;}
        public int IdTipoGeneroFK {get; set;}
        public TipoGenero TipoGenero {get; set;}
        public ICollection<Matricula> Matriculas { get; set; }
        public ICollection<PersonaSalon> PersonasSalones { get; set; }
    }
}