using System.Threading.Tasks;
using VetS.Core;

namespace VetS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VetSDbContext context;

        public UnitOfWork(VetSDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
