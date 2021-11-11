using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.players.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using System.Linq;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.relationships.repository
{
    public class relationshipsRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public relationshipsRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }
        
        public async Task Save(RelationShip relationShip)
        {
            _socialNetworkDbContext.RelationShips.Add(relationShip);
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        public List<RelationShip> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.RelationShips select VAR).ToList();
        }
        public RelationShip FindbyId(RelationshipId relationshipId)
        {
            RelationShip relationShip= (from VAR in _socialNetworkDbContext.RelationShips
                where VAR.Id == relationshipId
                select VAR).SingleOrDefault();
            if (relationShip==null)
            {
                throw new ArgumentNullException();
            }

            return relationShip;
        }
        
        public async Task RemoveIntroductionRequest(RelationshipId relationshipId)
        {
            _socialNetworkDbContext.RelationShips.Remove(this.FindbyId(relationshipId));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
    }
}