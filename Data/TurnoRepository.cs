using AutoMapper;
using System.Threading.Tasks;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Data
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly VetSDbContext context;
        private readonly IMapper mapper;

        public TurnoRepository(VetSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Turno> GetTurno(int id)
        {
            return await context.Turnos.FindAsync(id);
        }

        public void Add(Turno turno)
        {
            context.Turnos.Add(turno);
        }

        public void Remove(Turno turno)
        {
            context.Turnos.Remove(turno);
        }
    }
}
