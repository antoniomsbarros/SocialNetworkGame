using System;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.infrastructure.relationships
{
    public interface IRelationshipRepository: IRepository<Relationship, RelationshipId>
    {
        public Task<List<Relationship>> GetRelationshipsFriendsById(PlayerId id);

        public Task UpdateRelationship(String relationshipId, List<String> relationTag, int connectionStrength);
    }
}