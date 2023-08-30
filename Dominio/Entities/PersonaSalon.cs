using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class PersonaSalon
    {
        public int IdPersonaFK {get; set;}
        public Persona Persona {get; set;}
        public int IdSalonFk {get; set;}
        public Salon Salon {get; set;}
    }
}