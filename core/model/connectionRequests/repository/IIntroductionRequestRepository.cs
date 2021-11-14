using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.connectionRequests.repository
{
    public interface IIntroductionRequestRepository : IRepository<IntroductionRequest, ConnectionRequestId>
    {
        List<IntroductionRequest> GetAllPendingIntroductionAsync(PlayerId playerIntroductionId);

        List<IntroductionRequest> GetIntrosById(PlayerId id);

        List<IntroductionRequest> GetALLPendingAprovalAsync(PlayerId playerRecever);
    }
}