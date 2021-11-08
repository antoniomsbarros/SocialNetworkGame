using System.Threading.Tasks;

namespace LEI_21s5_3dg_41.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}