using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public abstract class ConnectionRequest : Entity<ConnectionRequestId>, IAggregateRoot
    {
        public ConnectionRequestStatus ConnectionRequestStatus { get; private set; }

        public PlayerId PlayerSender { get; private set; }

        public PlayerId PlayerReceiver { get; private set; }

        public TextBox Text { get; private set; }

        public CreationDate CreationDate { get; private set; }

        // The connection strength and the list of tags is for the relation
        // that's going to be established between two users if the request is accepted
        public ConnectionStrength ConnectionStrengthConf { get; private set; }

        public List<TagId> TagsConf { get; }

        protected ConnectionRequest()
        {
            // for ORM
        }

        protected ConnectionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, CreationDate creationDate,
            ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
        {
            Id = id;
            ConnectionRequestStatus = status;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = creationDate;
            ConnectionStrengthConf = connectionStrengthConf;
            TagsConf = new(tagsConf);
        }

        protected ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, PlayerId playerSender,
            PlayerId playerReceiver, TextBox text, ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
        {
            Id = new ConnectionRequestId(Guid.NewGuid());
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = new();
            ConnectionStrengthConf = connectionStrengthConf;
            TagsConf = new(tagsConf);
        }

        protected ConnectionRequest(PlayerId playerSender,
            PlayerId playerReceiver, TextBox text, ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
        {
            Id = new ConnectionRequestId(Guid.NewGuid());
            ConnectionRequestStatus = new(ConnectionRequestStatusEnum.OnHold);
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = new();
            ConnectionStrengthConf = connectionStrengthConf;
            TagsConf = new(tagsConf);
        }

        public void ChangeStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            ConnectionRequestStatus = connectionRequestStatus;
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

        public void ChangeConnectionStrength(ConnectionStrength connectionStrength)
        {
            ConnectionStrengthConf = connectionStrength;
        }

        public void ChangeTags(List<TagId> tags)
        {
            if (tags != null)
            {
                TagsConf.Clear();
                TagsConf.AddRange(tags);
            }
        }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}