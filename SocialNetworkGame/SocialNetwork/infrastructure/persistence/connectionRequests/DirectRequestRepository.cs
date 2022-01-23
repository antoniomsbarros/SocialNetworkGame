using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
{
    public class DirectRequestRepository : BaseRepository<DirectRequest, ConnectionRequestId>,
        IDirectRequestRepository
    {
        private readonly DbSet<DirectRequest> _directRequests;

        public DirectRequestRepository(SocialNetworkDbContext socialNetworkDbContext)
            : base(socialNetworkDbContext.DirectRequests)
        {
            _directRequests = socialNetworkDbContext.DirectRequests;
        }
        
        
        public List<DirectRequest> GetPendingRequestsAsync(PlayerId playerReceiverId)
        {
            return _directRequests
                .Where(x=>x.PlayerReceiver.Equals(playerReceiverId))
                .Where(x=> x.ConnectionRequestStatus.CurrentStatus.Equals(ConnectionRequestStatusEnum.OnHold))
                .ToList();
        }
    }
}