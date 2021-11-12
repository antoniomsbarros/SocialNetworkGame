using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public abstract class ConnectionRequest : Entity<ConnectionRequestId>, IAggregateRoot
    {
        public ConnectionRequestStatus ConnectionRequestStatus { get; set; }

        public PlayerId PlayerSender { get; set; }

        public PlayerId PlayerReceiver { get; set; }

        public TextBox Text { get; set; }

        public CreationDate CreationDate { get; }

       public ConnectionStrenght ConnectionStrenghtsender { get; }

       public List<Tag> Tags;

        protected ConnectionRequest()
        {
            // for ORM
        }

        protected ConnectionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, CreationDate creationDate,
            ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
        {
            this.Id = id;
            this.ConnectionRequestStatus = status;
            this.PlayerSender = playerSender.Id;
            this.PlayerReceiver = playerReceiver.Id;
            this.Text = text;
            this.CreationDate = creationDate;
            this.ConnectionStrenghtsender = connectionStrenghtsender;
            Tags = tags;
        }

        protected ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, Player playerSender, 
            Player playerRecever, TextBox text,ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
        {
            this.Id = new ConnectionRequestId(Guid.NewGuid());
            this.ConnectionRequestStatus = connectionRequestStatus;
            this.PlayerSender = playerSender.Id;
            this.PlayerReceiver = playerRecever.Id;
            this.Text = text;
            this.CreationDate = new();
            this.ConnectionStrenghtsender = connectionStrenghtsender;
            Tags = tags;
        }
        public ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, PlayerId playerSender, 
            PlayerId playerRecever, TextBox text,ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
        {
            this.Id = new ConnectionRequestId(Guid.NewGuid());
            this.ConnectionRequestStatus = connectionRequestStatus;
            this.PlayerSender = playerSender;
            this.PlayerReceiver = playerRecever;
            this.Text = text;
            this.CreationDate = new();
            this.ConnectionStrenghtsender = connectionStrenghtsender;
            Tags = tags;
        }

        public void ChangeStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            this.ConnectionRequestStatus = connectionRequestStatus;
        }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}