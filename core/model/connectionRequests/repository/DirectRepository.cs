using SocialNetwork.infrastructure;

namespace SocialNetwork.core.model.connectionRequests.repository
{
    public class DirectRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public DirectRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }
    }
    
}