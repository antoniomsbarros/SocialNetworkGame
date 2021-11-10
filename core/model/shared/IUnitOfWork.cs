using System.Threading.Tasks;

namespace SocialNetwork.core.model.shared
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}