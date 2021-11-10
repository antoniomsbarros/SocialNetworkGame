using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.infrastructure;

namespace SocialNetwork.core.model.connectionRequests.repository
{
    public class ConnectionRequestRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;


        public ConnectionRequestRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }

        public async Task Save(ConnectionRequest c)
        {
            _socialNetworkDbContext.ConnectionRequests.Add(c);
            await _socialNetworkDbContext.SaveChangesAsync();
        }

        public List<ConnectionRequest> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.ConnectionRequests select VAR).ToList();
        }

        public ConnectionRequest FindById(ConnectionRequestId id)
        {
            ConnectionRequest connectionRequest = (from s in _socialNetworkDbContext.ConnectionRequests
                where s.Id == id
                select s).SingleOrDefault();
            if (connectionRequest==null)
            {
                throw new ArgumentNullException();
            }

            return connectionRequest;
        }

        public async Task RemoveConnectionRequest(ConnectionRequestId id)
        {
            _socialNetworkDbContext.ConnectionRequests.Remove(FindById(id));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        

    }
}