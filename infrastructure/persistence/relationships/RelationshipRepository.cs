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
        public RelationshipRepository(SocialNetworkDbContext context) : base(context.Relationships)
        {
        }

        public async Task<List<Relationship>> GetRelationshipsFriendsById(PlayerId id)
        {
            return await this._objs.Where(x => x.PlayerOrig.Value.Equals(id.Value)).ToListAsync();
        }
    }
}