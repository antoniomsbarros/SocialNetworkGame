using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.connectionRequests.repository
{
    public interface IDirectRequestRepository : IRepository<DirectRequest, ConnectionRequestId>
    {
    }
}