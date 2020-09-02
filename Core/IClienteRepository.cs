using System.Threading.Tasks;
using VetS.Core.Models;

namespace VetS.Core
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(int id);
        void Add(Cliente cliente);
        void Remove(Cliente cliente);
    }
}