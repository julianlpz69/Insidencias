using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonaController : BaseApiController
    {
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

        [HttpGet]
        //[MapToApiVersion("1.1")]//
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var personas = await unitofwork.Personas.GetAllAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var cliente = await unitofwork.Personas.GetByIdAsync(id);
            return mapper.Map<PersonaDto>(cliente);
        }


          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Persona>> Post([FromBody]PersonaDto personaDto)
          {
              var persona = mapper.Map<Persona>(personaDto);
              unitofwork.Personas.Add(persona);
              await unitofwork.SaveAsync();

              if (persona == null){
                  return BadRequest();
              }
              personaDto.Id = persona.Id;
              return CreatedAtAction(nameof(Post), new {id = personaDto.Id}, personaDto); 
           }



    //   [HttpPost]
    //   [ProducesResponseType(StatusCodes.Status200OK)]
    //   [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //   public async Task<ActionResult<Persona>> Post(Persona persona)
    //   {
    //       this.unitofwork.Personas.Add(persona);
    //       await unitofwork.SaveAsync();
    //       if (persona == null){
    //           return BadRequest();
    //       }
    //       return CreatedAtAction(nameof(Post), new { id = persona.Id }, persona);
    //   }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto PersonaDto){
            if(PersonaDto == null)
                return NotFound();

            var Persona = this.mapper.Map<Persona>(PersonaDto);
            unitofwork.Personas.Update(Persona);
            await unitofwork.SaveAsync();
            return PersonaDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var persona = await unitofwork.Personas.GetByIdAsync(id);
            if(persona == null)
                return NotFound();
            
            unitofwork.Personas.Remove(persona);
            await unitofwork.SaveAsync();
            return NoContent();    }
    }
}