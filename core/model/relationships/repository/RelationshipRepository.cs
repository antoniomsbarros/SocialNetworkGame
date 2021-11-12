using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.DTO;
using SocialNetwork.infrastructure;
using SocialNetwork.infrastructure.persistence.Shared;
using SocialNetwork.infrastructure.relationships;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.relationships.repository
{
    public class RelationshipRepository : BaseRepository<Relationship, RelationshipId>, IRelationshipRepository
    {

        private readonly DbSet<Relationship> _relationships;

        public RelationshipRepository(SocialNetworkDbContext context) : base(context.Relationships)
        {
            _relationships = context.Relationships;
        }

        public async Task<List<Relationship>> GetRelationshipsFriendsById(PlayerId id)
        {
            return await _relationships.Where(x => x.PlayerOrig.Value.Equals(id.Value)).ToListAsync();
        }
    }

}