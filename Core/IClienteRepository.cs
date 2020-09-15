using System.Collections.Generic;
using System.Threading.Tasks;
using VetS.Controllers.Resources;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(int id);
        Task<IEnumerable<ClienteResource>> GetClientes();
        void Add(Cliente cliente);
        void Remove(Cliente cliente);
    }
}