using SocialNetwork.core.model.players.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using System.Linq;
namespace SocialNetwork.core.model.players.repository
{
    public class PlayerRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public PlayerRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }
        
        public async Task Save(Player player)
        {
            _socialNetworkDbContext.Players.Add(player);
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        public List<Player> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.Players select VAR).ToList();
        }
        public Player FindbyId(PlayerId playerId)
        {
            Player player= (from VAR in _socialNetworkDbContext.Players
                where VAR.Id == playerId
                select VAR).SingleOrDefault();
            if (player==null)
            {
                throw new ArgumentNullException();
            }

            return player;
        }
        
        public async Task RemoveIntroductionRequest(PlayerId player)
        {
            _socialNetworkDbContext.Players.Remove(this.FindbyId(player));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
    }
}