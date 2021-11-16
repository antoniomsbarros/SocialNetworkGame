using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using SocialNetwork.core.model.relationships.domain;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.dto;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class DirectRequest : ConnectionRequest, IDTOable<DirectRequestDTO>
    {
        protected DirectRequest() : base()
        {
            // for ORM
        }

        protected DirectRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, CreationDate creationDate,
            ConnectionStrenght connectionStrengthSender, List<Tag> tags)
            : base(id, status, playerSender, playerReceiver, text, creationDate, connectionStrengthSender, tags)
        {
        }

        public DirectRequest(ConnectionRequestStatus connectionRequestStatus, PlayerId playerSender,
            PlayerId playerReceiver,
            TextBox text, ConnectionStrenght connectionStrengthSender, List<Tag> tags)
            : base(connectionRequestStatus, playerSender, playerReceiver, text, connectionStrengthSender, tags)
        {
        }
        
        public DirectRequest(PlayerId playerSender, PlayerId playerReceiver, TextBox text, 
            ConnectionStrenght connectionStrengthSender, List<Tag> tags)
            : base(playerSender, playerReceiver, text, connectionStrengthSender, tags)
        {
        }

        public DirectRequestDTO ToDto()
        {
            return new DirectRequestDTO(
                Id.Value, ConnectionRequestStatus.CurrentStatus, PlayerSender.Value, PlayerReceiver.Value,
                Text.Text, CreationDate.Date);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(DirectRequest))
                return false;

            DirectRequest otherDirectRequest = (DirectRequest) obj;

            return otherDirectRequest.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}