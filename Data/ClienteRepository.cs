using System.Threading.Tasks;
using VetS.Core;
using VetS.Core.Models;

namespace VetS.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VetSDbContext context;

        public ClienteRepository(VetSDbContext context)
        {
            this.context = context;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await context.Clientes.FindAsync(id);
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
