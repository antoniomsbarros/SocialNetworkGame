using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.missions.MissionRepository;
using SocialNetwork.core.model.players.repository;
using SocialNetwork.core.model.posts.repository;
using SocialNetwork.core.model.relationships.repository;

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

        public PlayerRepository PlayerRepository()
        {
            return new PlayerRepository(_context);
        }

        public MissionRepository MissionRepository()
        {
            return new MissionRepository(_context);
        }

        public RelationshipsRepository RelationshipsRepository()
        {
            return new RelationshipsRepository(_context);
        }

        public PostRepository PostRepository()
        {
            return new PostRepository(_context);
        }
    }
}