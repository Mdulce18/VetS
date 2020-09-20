using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface IMascotaRepository
    {
        Task<Mascota> GetMascota(int id, bool IncludeRelated = true);
        Task<IEnumerable<MascotaResource>> GetListaMascotas();
        Task<QueryResult<Mascota>> GetTodasLasMascotas(MascotaQuery filtro);
        void Add(Mascota mascota);
        void Remove(Mascota mascota);
    }
}