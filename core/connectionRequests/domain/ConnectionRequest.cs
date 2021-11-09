using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.connectionRequests.domain
{
    public abstract class ConnectionRequest : Entity<ConnectionRequestId>, IAggregateRoot
    {
        public ConnectionRequestStatus ConnectionRequestStatus { get; set; }
        public Player PlayerSender { get; set; }
        public Player PlayerRecever { get; set; }
        public TextBox Text { get; set; }
        protected ConnectionRequest()
        {
            // Empty constructor
        }

        protected ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, Player playerSender, Player playerRecever, TextBox text)
        {
            this.Id = new(Guid.NewGuid());
            this.ConnectionRequestStatus = connectionRequestStatus;
            this.PlayerSender = playerSender;
            this.PlayerRecever = playerRecever;
            this.Text = text;
        }

        public void ChangeStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            this.ConnectionRequestStatus = connectionRequestStatus;
        }

    }
}