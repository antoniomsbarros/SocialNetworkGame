using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.core.model.relationships.repository
{
    public interface IRelationshipRepository : IRepository<Relationship, RelationshipId>
    {
        public Task<List<Relationship>> GetRelationshipsFromPlayerById(PlayerId id);

        Task<Relationship> GetRelationshipBetweenPlayers(PlayerId playerFrom, PlayerId playerDest);

        //TODO To fix!!
        public Task UpdateRelationship(string relationshipId, List<string> relationTag, int connectionStrength);
    }
}