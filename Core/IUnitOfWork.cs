using System.Threading.Tasks;

namespace VetS.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}