using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.infrastructure;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class IntroductionRequestServices
    {
        private ConnectionRequestRepository _connectionRequestRepository;
        private IntroductionRequestRepository _introductionRequestRepository;
        //private Player

        public IntroductionRequestServices(SocialNetworkDbContext socialNetworkDbContext)
        {
           // _connectionRequestRepository = socialNetworkDbContext.R;
            //_introductionRequestRepository = introductionRequestRepository;
            
        }
         
    }
}