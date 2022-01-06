using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.infrastructure.persistence.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.repository;

namespace SocialNetwork.infrastructure.persistence.relationships
{
    public class RelationshipRepository : BaseRepository<Relationship, RelationshipId>, IRelationshipRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public RelationshipRepository(SocialNetworkDbContext context) : base(context.Relationships)
        {
            _socialNetworkDbContext = context;
        }

        public async Task<List<Relationship>> GetRelationshipsFromPlayerById(PlayerId id)
        {
            return await _objs.Where(relationship => relationship.PlayerOrig.Value.Equals(id.Value)).ToListAsync();
        }

        public async Task UpdateRelationship(string relationshipId, List<string> relationTag, int connectionStrength)
        {
            await _socialNetworkDbContext.SaveChangesAsync();
        }

        public async Task<Relationship> GetRelationshipOfPlayerFromTo(Email playerFrom, Email playerDest)
        {
            var rela = await this._socialNetworkDbContext.Set<Relationship>()
                .Where(x => playerFrom.Equals(x.PlayerOrig.ToString()))
                .Where(y => playerDest.Equals(y.PlayerDest.ToString()))
                .FirstOrDefaultAsync();

            return rela;
        }
    }
}