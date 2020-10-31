using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
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

        public async Task<IEnumerable<TurnoResource>> GetTodosLosTurnos()
        {
            var turnos = await context.Turnos.Include(t => t.TipoTurno).ToListAsync();
            return mapper.Map<List<Turno>, List<TurnoResource>>(turnos);
        }
        public async Task<IEnumerable<TipoTurnoResource>> GetTipoDeTurnos()
        {
            var tipoTurnos = await context.TipoTurnos.ToListAsync();
            return mapper.Map<List<TipoTurno>, List<TipoTurnoResource>>(tipoTurnos);
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
