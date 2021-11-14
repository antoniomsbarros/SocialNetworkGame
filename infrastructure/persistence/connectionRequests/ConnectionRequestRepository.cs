using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.infrastructure;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
{
    public class ConnectionRequestRepository : BaseRepository<ConnectionRequest, ConnectionRequestId>, IConnectionRequestRepository
    {
        public ConnectionRequestRepository(SocialNetworkDbContext context) : base(context.ConnectionRequests)
        {
        }
    }
}