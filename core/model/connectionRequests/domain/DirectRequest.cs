using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using SocialNetwork.core.model.relationships;
using SocialNetwork.core.model.relationships.domain;
using System.Collections.Generic;
namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class DirectRequest : ConnectionRequest
    {
        protected DirectRequest() : base()  
        {
            // for ORM
        }

        protected DirectRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, CreationDate creationDate,ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
            : base(id, status, playerSender, playerReceiver, text, creationDate,connectionStrenghtsender, tags)
        {
        }

        public DirectRequest(ConnectionRequestStatus connectionRequestStatus, Player playerSender, Player playerRecever, 
            TextBox text,ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
            : base(connectionRequestStatus, playerSender, playerRecever, text,connectionStrenghtsender, tags)
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