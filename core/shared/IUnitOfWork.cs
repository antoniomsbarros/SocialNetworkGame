using System.Threading.Tasks;

namespace SocialNetwork.core.shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}