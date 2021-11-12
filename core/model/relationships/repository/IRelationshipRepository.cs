using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.infrastructure.relationships
{
    public interface IRelationshipRepository: IRepository<Relationship, RelationshipId>
    {
        public Task<List<Relationship>> GetRelationshipsFriendsById(PlayerId id);
    }
}