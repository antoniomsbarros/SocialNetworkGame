using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public enum ConnectionRequestStatusEnum
    {
        Approved,
        Rejected,
        OnHold
    }

    public class ConnectionRequestStatus : IValueObject
    {

        public ConnectionRequestStatusEnum CurrentStatus { get; }

        protected ConnectionRequestStatus()
        {
            // for ORM
        }

        public ConnectionRequestStatus(ConnectionRequestStatusEnum status)
        {
            this.CurrentStatus = status;
        }

        public static ConnectionRequestStatus ValueOf(ConnectionRequestStatusEnum status)
        {
            return new(status);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(ConnectionRequestStatus))
                return false;

            ConnectionRequestStatus otherStatus = (ConnectionRequestStatus)obj;

            return otherStatus.CurrentStatus.Equals(this.CurrentStatus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.CurrentStatus);
        }
    }

}