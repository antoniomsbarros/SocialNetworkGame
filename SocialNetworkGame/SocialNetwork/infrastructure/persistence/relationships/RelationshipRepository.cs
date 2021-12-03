using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.infrastructure.persistence.Shared;
using SocialNetwork.infrastructure.relationships;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.infrastructure.persistence.relationships
{
    public class RelationshipRepository : BaseRepository<Relationship, RelationshipId>, IRelationshipRepository
    {
        
        
        private SocialNetworkDbContext _socialNetworkDbContext;
        public RelationshipRepository(SocialNetworkDbContext context) : base(context.Relationships)
        {
            _socialNetworkDbContext = context;
        }

        public async Task<List<Relationship>> GetRelationshipsFriendsById(PlayerId id)
        {
            return await this._objs.Where(x => x.PlayerOrig.Value.Equals(id.Value)).ToListAsync();
        }

        public async Task UpdateRelationship(string relationshipId, List<string> relationTag, int connectionStrength)
        {
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        
        public async Task<Relationship> GetRelationshipOfPlayerFromTo(Email playerFrom, Email playerDest)
        {

            var rela = await this._socialNetworkDbContext.Set<Relationship>()
                .Where(x => playerFrom.Equals(x.PlayerOrig.ToString()))
                .Where(y=>playerDest.Equals(y.PlayerDest.ToString()))
                .FirstOrDefaultAsync(); 
            
            return rela;

        }
    }
}