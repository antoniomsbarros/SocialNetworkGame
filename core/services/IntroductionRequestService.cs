using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.infrastructure;

namespace SocialNetwork.core.model.posts.application
{
    public class IntroductionRequestService
    {
        private IntroductionRequestRepository _introductionRequestRepository;
        private ConnectionRequestRepository _connectionRequestRepository;

        public IntroductionRequestService(SocialNetworkDbContext context)
        {
            _introductionRequestRepository = context.repositories().IntroductionRequest();
            _connectionRequestRepository = context.repositories().ConnectionRequest();
        }
    }
}