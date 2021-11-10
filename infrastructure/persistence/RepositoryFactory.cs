using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;

namespace SocialNetwork.infrastructure.persistence
{
    public class RepositoryFactory
    {
        private SocialNetworkDbContext _context;

        public RepositoryFactory(SocialNetworkDbContext context)
        {
            _context = context;
        }

        public ConnectionRequestRepository ConnectionRequest()
        {
            return new ConnectionRequestRepository(_context);
        }

        public DirectRepository DirectRepository()
        {
            return new DirectRepository(_context);
        }
        
        public IntroductionRequestRepository IntroductionRequest()
        {
            return new IntroductionRequestRepository(_context);
        }
         
    }
}