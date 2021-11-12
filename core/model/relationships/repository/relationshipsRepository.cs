using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.infrastructure;
using System.Linq;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.relationships.repository
{
    public class RelationshipsRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public RelationshipsRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }

        public async Task Save(Relationship relationShip)
        {
            _socialNetworkDbContext.Relationships.Add(relationShip);
            await _socialNetworkDbContext.SaveChangesAsync();
        }

        public List<Relationship> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.Relationships select VAR).ToList();
        }

        public Relationship FindbyId(RelationshipId relationshipId)
        {
            Relationship relationShip = (from VAR in _socialNetworkDbContext.Relationships
                where VAR.Id == relationshipId
                select VAR).SingleOrDefault();
            if (relationShip == null)
            {
                throw new ArgumentNullException();
            }

            return relationShip;
        }

        public async Task RemoveIntroductionRequest(RelationshipId relationshipId)
        {
            _socialNetworkDbContext.Relationships.Remove(this.FindbyId(relationshipId));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
    }
}