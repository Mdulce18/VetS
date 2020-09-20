using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core;
using VetS.Core.Models;
using VetS.Extensions;

namespace VetS.Data
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly VetSDbContext context;
        private readonly IMapper mapper;

        public MascotaRepository(VetSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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

        public async Task<QueryResult<Mascota>> GetTodasLasMascotas(MascotaQuery queryObj)
        {
            var result = new QueryResult<Mascota>();

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

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

        public async Task<IEnumerable<MascotaResource>> GetListaMascotas()
        {
            var mascotas = await context.Mascotas.ToListAsync();
            return mapper.Map<List<Mascota>, List<MascotaResource>>(mascotas);
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
