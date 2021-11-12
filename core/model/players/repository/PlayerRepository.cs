using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Player> GetByEmailAsync(Email email)
        {
            return await this._objs
                .Where(x => x.Email.EmailAddress.Equals(email.EmailAddress))
                .FirstOrDefaultAsync();
        }
    }
}