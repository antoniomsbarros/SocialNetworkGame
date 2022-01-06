using System;
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

        public Task UpdateRelationship(String relationshipId, List<String> relationTag, int connectionStrength);

        Task<Relationship> GetRelationshipOfPlayerFromTo(Email playerFrom, Email playerDest);
    }
}