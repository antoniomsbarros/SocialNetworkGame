using System.Threading.Tasks;
using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LEI_21s5_3dg_41DbContext _context;

        public UnitOfWork(LEI_21s5_3dg_41DbContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}