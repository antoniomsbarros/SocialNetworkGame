using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.infrastructure.relationships
{
    public interface IRelationshipRepository: IRepository<Relationship, RelationshipId>
    {
    }
}