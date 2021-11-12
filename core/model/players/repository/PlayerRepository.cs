using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.core.model.players.repository
{
    public class PlayerRepository : BaseRepository<Player, PlayerId>, IPlayerRepository
    {
        public PlayerRepository(SocialNetworkDbContext context) : base(context.Players)
        {
        }
    }
}