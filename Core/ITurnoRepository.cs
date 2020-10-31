using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface ITurnoRepository
    {
        Task<Turno> GetTurno(int id);
        Task<IEnumerable<TurnoResource>> GetTodosLosTurnos();
        Task<IEnumerable<TipoTurnoResource>> GetTipoDeTurnos();
        void Add(Turno turno);
        void Remove(Turno turno);
    }
}
