using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.connectionRequests.dto;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public abstract class ConnectionRequest : Entity<ConnectionRequestId>, IAggregateRoot
    {
        public ConnectionRequestStatus ConnectionRequestStatus { get; set; }

        public PlayerId PlayerSender { get; set; }

        public PlayerId PlayerReceiver { get; set; }

        public TextBox Text { get; set; }

        public CreationDate CreationDate { get; set; }

        public ConnectionStrenght ConnectionStrengthSender { get; set; }

        public List<Tag> Tags { get; set; }

        protected ConnectionRequest()
        {
            // for ORM
        }

        protected ConnectionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, CreationDate creationDate,
            ConnectionStrenght connectionStrengthSender, List<Tag> tags)
        {
            this.Id = id;
            this.ConnectionRequestStatus = status;
            this.PlayerSender = playerSender;
            this.PlayerReceiver = playerReceiver;
            this.Text = text;
            this.CreationDate = creationDate;
            this.ConnectionStrengthSender = connectionStrengthSender;
            Tags = tags;
        }

        protected ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, PlayerId playerSender,
            PlayerId playerReceiver, TextBox text, ConnectionStrenght connectionStrengthSender, List<Tag> tags)
        {
            this.Id = new ConnectionRequestId(Guid.NewGuid());
            this.ConnectionRequestStatus = connectionRequestStatus;
            this.PlayerSender = playerSender;
            this.PlayerReceiver = playerReceiver;
            this.Text = text;
            this.CreationDate = new();
            this.ConnectionStrengthSender = connectionStrengthSender;
            Tags = tags;
        }

        protected ConnectionRequest(PlayerId playerSender,
            PlayerId playerReceiver, TextBox text, ConnectionStrenght connectionStrengthSender, List<Tag> tags)
        {
            this.Id = new ConnectionRequestId(Guid.NewGuid());
            this.ConnectionRequestStatus = new(ConnectionRequestStatusEnum.OnHold);
            this.PlayerSender = playerSender;
            this.PlayerReceiver = playerReceiver;
            this.Text = text;
            this.CreationDate = new();
            this.ConnectionStrengthSender = connectionStrengthSender;
            Tags = tags;
        }

        public void ChangeStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            this.ConnectionRequestStatus = connectionRequestStatus;
        }

        public void ChangePlayerSender(PlayerId playerSenderId)
        {
            PlayerSender = playerSenderId;
        }

        public void ChangePLayerReceiver(PlayerId playerReceiverId)
        {
            PlayerReceiver = playerReceiverId;
        }

        public void ChangeText(TextBox textBox)
        {
            Text = textBox;
        }

        public void ChangeCreationDate(CreationDate creationDate)
        {
            CreationDate = creationDate;
        }

        public void ChangeConnectionStrenght(ConnectionStrenght connectionStrenght)
        {
            ConnectionStrengthSender = connectionStrenght;
        }

        public void ChangeTags(List<string> tags)
        {
            if (tags != null || tags.Count > 0)
            {
                Tags = new List<Tag>();
                tags.ForEach(tag => Tags.Add(new Tag(tag)));
            }
        }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();

    }
}