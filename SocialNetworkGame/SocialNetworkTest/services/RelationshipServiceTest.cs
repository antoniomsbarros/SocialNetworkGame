using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.infrastructure.relationships;

namespace SocialNetworkTest.services
{
    [TestClass]
    public class RelationshipServiceTest
    {
        private class UnitOfWorkMockMock : IUnitOfWork
        {
            public Task<int> CommitAsync()
            {
                return new Task<int>(() => 1);
            }
        }

        private class RelationshipRepositoryMock : IRelationshipRepository
        {
            public Task<List<Relationship>> GetAllAsync()
            {
                throw new System.NotImplementedException();
            }

            public Task<Relationship> GetByIdAsync(RelationshipId id)
            {
                throw new System.NotImplementedException();
            }

            public Task<List<Relationship>> GetByIdsAsync(List<RelationshipId> ids)
            {
                throw new System.NotImplementedException();
            }

            public Task<Relationship> AddAsync(Relationship obj)
            {
                throw new System.NotImplementedException();
            }

            public void Remove(Relationship obj)
            {
                throw new System.NotImplementedException();
            }

            public Task<List<Relationship>> GetRelationshipsFriendsById(PlayerId id)
            {
                throw new System.NotImplementedException();
            }

            public Task UpdateRelationship(string relationshipId, List<string> relationTag, int connectionStrength)
            {
                throw new System.NotImplementedException();
            }

            public Task<Relationship> GetRelationshipOfPlayerFromTo(Email playerFrom, Email playerDest)
            {
                throw new System.NotImplementedException();
            }

            [TestMethod]
            public void CreateRelationship()
            {
            }
        }
    }
}