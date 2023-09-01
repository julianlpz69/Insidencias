using Aplicacion.Repository;
using Dominio.Intefaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IncidenciasContext context;
        private PersonaRepository _personas;


        public UnitOfWork(IncidenciasContext _context)
        {
            context = _context;
        }

        public IPersona Personas
        {
            get{
                if (_personas == null)
                {
                    _personas = new PersonaRepository(context);
                }
                return _personas;
            }

        }


        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
