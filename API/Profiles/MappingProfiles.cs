
using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Aplicacion.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            
            CreateMap<Persona,PersonaDto>().ReverseMap();

        }
    }
}