using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.players
{
    public class PlayerRepository : BaseRepository<Player, PlayerId>, IPlayerRepository
    {
        private readonly SocialNetworkDbContext context;

        public PlayerRepository(SocialNetworkDbContext context) : base(context.Players)
        {
            this.context = context;
        }

        public async Task<Player> GetByEmailAsync(Email email)
        {
            return await _objs
                .Where(player => player.Email.Address.Equals(email.Address))
                .FirstOrDefaultAsync();
        }
    }
}