using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.connectionRequests.domain
{
    public class DirectRequest : ConnectionRequest
    {
        protected DirectRequest() : base()
        {
            // for ORM
        }

        protected DirectRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, CreationDate creationDate)
            : base(id, status, playerSender, playerReceiver, text, creationDate)
        {
        }

        public DirectRequest(ConnectionRequestStatus connectionRequestStatus, Player playerSender, Player playerRecever, TextBox text)
            : base(connectionRequestStatus, playerSender, playerRecever, text)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(DirectRequest))
                return false;

            DirectRequest otherDirectRequest = (DirectRequest)obj;

            return otherDirectRequest.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}