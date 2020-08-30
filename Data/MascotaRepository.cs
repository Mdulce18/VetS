using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VetS.Core;
using VetS.Core.Models;
using VetS.Extensions;

namespace VetS.Data
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly VetSDbContext context;

        public MascotaRepository(VetSDbContext context)
        {
            this.context = context;
        }
        public async Task<Mascota> GetMascota(int id, bool IncludeRelated = true)
        {
            if (!IncludeRelated)
                return await context.Mascotas.FindAsync(id);

            return await context.Mascotas
                .Include(m => m.Animal)
                .ThenInclude(m => m.Razas)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Mascota>> GetTodasLasMascotas(MascotaQuery queryObj)
        {
            //return await 
            var query = context.Mascotas
              .Include(m => m.Animal)
                  .ThenInclude(m => m.Razas)
              .AsQueryable();


            if (queryObj.AnimalId.HasValue)
                query = query.Where(m => m.Animal.Id == queryObj.AnimalId.Value);

            var columnas = new Dictionary<string, Expression<Func<Mascota, object>>>()
            {
                ["Nombre"] = m => m.Nombre,
                ["Animal"] = m => m.Animal.Nombre,
                ["Raza"] = m => m.Raza.Nombre,
                ["Fecha de Nacimiento"] = m => m.FechaNacimiento,
                ["Última Actualización"] = m => m.Actualizacion,
            };

            query = query.ApplyOrdering(queryObj, columnas);

            return await query.ToListAsync();
        }
        public void Add(Mascota mascota)
        {
            context.Mascotas.Add(mascota);
        }

        public void Remove(Mascota mascota)
        {
            context.Remove(mascota);
        }
    }
}
