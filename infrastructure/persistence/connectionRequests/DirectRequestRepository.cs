using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
{
    public class DirectRequestRepository : BaseRepository<DirectRequest, ConnectionRequestId>,
        IDirectRequestRepository
    {
        public DirectRequestRepository(SocialNetworkDbContext socialNetworkDbContext)
            : base(socialNetworkDbContext.DirectRequests)
        {
        }
    }
}