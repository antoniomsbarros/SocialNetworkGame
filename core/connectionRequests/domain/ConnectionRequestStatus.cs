using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    public enum ConnectionRequestStatusEnum
    {
        Approved,
        Rejected,
        Hold
    }
    public class ConnectionRequestStatus : IValueObject
    {

        public ConnectionRequestStatusEnum CurrentStatus { get; }

        public ConnectionRequestStatus(ConnectionRequestStatusEnum Status)
        {
            this.CurrentStatus = Status;
        }

    }

}