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
    public class ClienteRepository : IClienteRepository
    {
        private readonly VetSDbContext context;
        private readonly IMapper mapper;

        public ClienteRepository(VetSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<QueryResult<Cliente>> GetTodosLosClientess(ClienteQuery queryObj)
        {
            var result = new QueryResult<Cliente>();

            var query = context.Clientes
              .Include(c => c.Mascotas)
              .AsQueryable();


            //if (queryObj.MascotaId.HasValue)
            //    query = query.Where(c => c.Mascotas.SingleOrDefault(cm.MascotaId=queryObj.MascotaId.Value));

            var columnas = new Dictionary<string, Expression<Func<Cliente, object>>>()
            {
                ["Nombre"] = c => c.Nombre,
                ["Apellido"] = c => c.Apellido,
                ["D.N.I"] = c => c.DNI,
                ["Última Actualización"] = c => c.Actualizacion,
            };

            query = query.ApplyOrdering(queryObj, columnas);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }
        public async Task<Cliente> GetCliente(int id)
        {
            return await context.Clientes.Include(c => c.Mascotas).SingleOrDefaultAsync(c => c.Id == id);
        }


        public async Task<IEnumerable<ClienteResource>> GetClientes()
        {
            var clientes = await context.Clientes.Include(c => c.Mascotas).ToListAsync();
            return mapper.Map<List<Cliente>, List<ClienteResource>>(clientes);

        }

        public void Add(Cliente cliente)
        {
            context.Clientes.Add(cliente);
        }

        public void Remove(Cliente cliente)
        {
            context.Remove(cliente);
        }
    }
}
