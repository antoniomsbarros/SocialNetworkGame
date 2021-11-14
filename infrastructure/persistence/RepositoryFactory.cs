using SocialNetwork.infrastructure.persistence.connectionRequests;
using SocialNetwork.infrastructure.persistence.missions;
using SocialNetwork.infrastructure.persistence.players;
using SocialNetwork.infrastructure.persistence.posts;
using SocialNetwork.infrastructure.persistence.relationships;

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

        public DirectRequestRepository DirectRepository()
        {
            return new DirectRequestRepository(_context);
        }

        public IntroductionRequestRepository IntroductionRequest()
        {
            return new IntroductionRequestRepository(_context);
        }

        public PlayerRepository PlayerRepository()
        {
            return new PlayerRepository(_context);
        }

        public MissionRepository MissionRepository()
        {
            return new MissionRepository(_context);
        }

        public RelationshipRepository RelationshipsRepository()
        {
            return new RelationshipRepository(_context);
        }

        public PostRepository PostRepository()
        {
            return new PostRepository(_context);
        }
    }
}