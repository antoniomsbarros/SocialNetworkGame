using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
{
    public class IntroductionRequestRepository : BaseRepository<IntroductionRequest, ConnectionRequestId>,
        IIntroductionRequestRepository
    {
        private readonly DbSet<IntroductionRequest> _introductionRequests;

        public IntroductionRequestRepository(SocialNetworkDbContext socialNetworkDbContext) : base(
            socialNetworkDbContext.IntroductionRequests)
        {
            _introductionRequests = socialNetworkDbContext.IntroductionRequests;
        }

        public List<IntroductionRequest> GetAllPendingIntroductionAsync(PlayerId playerIntroductionId)
        {
            return _introductionRequests.Where(x => x.PlayerIntroduction.Equals(playerIntroductionId))
                .Where(x => x.ConnectionRequestStatus.CurrentStatus.Equals(ConnectionRequestStatusEnum
                    .Approved))
                .Where(x => x.IntroductionStatus.CurrentStatus.Equals(ConnectionRequestStatusEnum
                    .OnHold)).ToList();
        }

        public List<IntroductionRequest> GetIntrosById(PlayerId id)
        {
            return _introductionRequests.Where(x => x.PlayerReceiver.Equals(id)).ToList();
        }

        public List<IntroductionRequest> GetAllPendingApprovalAsync(PlayerId playerReceiver)
        {
            return _introductionRequests.Where(x => x.PlayerReceiver.Equals(playerReceiver)).Where(x =>
                x.ConnectionRequestStatus.CurrentStatus.Equals(ConnectionRequestStatusEnum
                    .OnHold)).ToList();
        }
    }
}