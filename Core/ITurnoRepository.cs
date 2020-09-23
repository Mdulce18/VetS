using System.Threading.Tasks;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface ITurnoRepository
    {
        Task<Turno> GetTurno(int id);
        void Add(Turno turno);
        void Remove(Turno turno);
    }
}
