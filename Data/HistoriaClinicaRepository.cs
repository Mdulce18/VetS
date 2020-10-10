using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Data
{
    public class HistoriaClinicaRepository : IHistoriaClinicaRepository
    {
        private readonly VetSDbContext context;

        public HistoriaClinicaRepository(VetSDbContext context)
        {
            this.context = context;
        }

        public async Task<HistoriaClinica> GetHistoria(int id)
        {
            return await context.HistoriaClinicas
                .Include(hc => hc.Mascota)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<HistoriaClinica>> GetListaHistorias(int mascotaId)
        {
            return await context.HistoriaClinicas.Where(hm => hm.MascotaId == mascotaId).ToListAsync();
        }

        public void Add(HistoriaClinica historiaClinica)
        {
            context.Add(historiaClinica);
        }


    }
}
