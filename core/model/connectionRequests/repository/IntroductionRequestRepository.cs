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

        private readonly DbSet<IntroductionRequest> _introductionRequests;
        public IntroductionRequestRepository(SocialNetworkDbContext socialNetworkDbContext) : base(socialNetworkDbContext.IntroductionRequests)
        {
            _introductionRequests = socialNetworkDbContext.IntroductionRequests;
        }
        
        public List<IntroductionRequest> GetAllPendingIntroductionAsync(PlayerId playerIntroductionId)
        {

            return _introductionRequests.Where(x => x.PlayerIntroduction.Equals(playerIntroductionId))
                .Where(x=> x.ConnectionRequestStatus.CurrentStatus.Equals(ConnectionRequestStatusEnum
                    .Approved))
                .Where(x=> x.IntroductionStatus.CurrentStatus.Equals(ConnectionRequestStatusEnum
                    .OnHold)).ToList();

        }
    }
}