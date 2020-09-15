using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core;
using VetS.Core.Models;

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

        public async Task<Cliente> GetCliente(int id)
        {
            //return await context.Clientes.FindAsync(id);
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
