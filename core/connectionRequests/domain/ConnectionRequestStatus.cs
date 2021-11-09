using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    public enum ConnectionRequestStatusEnum
    {
        Approved,
        Rejected,
        Hold
    }

    [Owned]
    public class ConnectionRequestStatus : IValueObject
    {

        public ConnectionRequestStatusEnum CurrentStatus { get; }

        protected ConnectionRequestStatus()
        {
            // for ORM
        }

        public ConnectionRequestStatus(ConnectionRequestStatusEnum Status)
        {
            this.CurrentStatus = Status;
        }

    }

}