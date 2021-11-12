using System.Threading.Tasks;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.repository
{
    public interface IPlayerRepository : IRepository<Player, PlayerId>
    {
        Task<Player> GetByEmailAsync(Email email);
    }
}