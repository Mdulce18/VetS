using System.Threading.Tasks;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface IMascotaRepository
    {
        Task<Mascota> GetMascota(int id, bool IncludeRelated = true);
        Task<QueryResult<Mascota>> GetTodasLasMascotas(MascotaQuery filtro);
        void Add(Mascota mascota);
        void Remove(Mascota mascota);
    }
}