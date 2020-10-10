using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface IHistoriaClinicaRepository
    {
        void Add(HistoriaClinica historiaClinica);
        Task<HistoriaClinica> GetHistoria(int id);
        Task<IEnumerable<HistoriaClinica>> GetListaHistorias(int mascotaId);
    }
}