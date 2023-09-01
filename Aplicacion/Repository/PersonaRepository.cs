using Dominio.Entities;
using Dominio.Intefaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly IncidenciasContext _context;
        public PersonaRepository(IncidenciasContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                .Include(p => p.Matriculas)
                .ToListAsync();
        }

        public override async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
            .Include(p => p.Matriculas)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}