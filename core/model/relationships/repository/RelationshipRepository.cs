using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.infrastructure;
using SocialNetwork.infrastructure.persistence.Shared;
using SocialNetwork.infrastructure.relationships;

namespace lapr5_3dg.infrastructure.relationships
{
    public class RelationshipRepository : BaseRepository<Relationship, RelationshipId>, IRelationshipRepository
    {
        public RelationshipRepository(SocialNetworkDbContext context) : base(context.Relationships)
        { 
        }
    }
}