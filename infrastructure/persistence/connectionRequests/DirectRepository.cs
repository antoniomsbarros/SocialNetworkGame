using SocialNetwork.infrastructure;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
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