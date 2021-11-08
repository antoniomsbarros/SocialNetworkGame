using System.Threading.Tasks;
using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialNetworkDbContext _context;

        public UnitOfWork(SocialNetworkDbContext context)
        {
            this._context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await this._context.SaveChangesAsync();
        }
    }
}