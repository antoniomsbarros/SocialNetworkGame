using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.core.model.connectionRequests.repository
{
    public class IntroductionRequestRepository:BaseRepository<IntroductionRequest,ConnectionRequestId>,IIntroductionRequestRepository
    {
        public IntroductionRequestRepository(SocialNetworkDbContext socialNetworkDbContext) : base(socialNetworkDbContext.IntroductionRequests)
        {
        }
        /*private SocialNetworkDbContext _socialNetworkDbContext;

        public IntroductionRequestRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }

        public async Task Save(IntroductionRequest introductionRequest)
        {
            _socialNetworkDbContext.IntroductionRequests.Add(introductionRequest);
            await _socialNetworkDbContext.SaveChangesAsync();
        }

        public List<IntroductionRequest> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.IntroductionRequests select VAR).ToList();
        }

        public List<IntroductionRequest> FindbyPlayerIntroductionIdThatAreOnHold(PlayerId playerId)
        {
            return (from VAR in _socialNetworkDbContext.IntroductionRequests
                where VAR.PlayerIntroduction == playerId && VAR.IntroductionStatus.Equals("OnHold")
                select VAR).ToList();
        }

        public IntroductionRequest FindbyId(ConnectionRequestId connectionRequestId)
        {
            IntroductionRequest introductionRequest= (from VAR in _socialNetworkDbContext.IntroductionRequests
                where VAR.Id == connectionRequestId
                select VAR).SingleOrDefault();
            if (introductionRequest==null)
            {
                throw new ArgumentNullException();
            }

            return introductionRequest;
        }

        public async Task UpdateStatusOfIntroduction(IntroductionRequest introductionRequest,
            ConnectionRequestStatus connectionRequestStatus)
        {
            introductionRequest.ChangeIntroductionStatus(connectionRequestStatus);
            _socialNetworkDbContext.IntroductionRequests.Update(introductionRequest);
            await _socialNetworkDbContext.SaveChangesAsync();
        }

        public async Task RemoveIntroductionRequest(ConnectionRequestId connectionRequestId)
        {
            _socialNetworkDbContext.IntroductionRequests.Remove(this.FindbyId(connectionRequestId));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        */
    }
}