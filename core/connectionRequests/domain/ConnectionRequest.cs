using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    public abstract class ConnectionRequest : Entity<ConnectionRequestId>, IAggregateRoot
    {
        public ConnectionRequestStatus ConnectionRequestStatus { get; set; }

        public Player PlayerSender { get; set; }

        public Player PlayerReceiver { get; set; }

        public TextBox Text { get; set; }

        public CreationDate CreationDate { get; }

        protected ConnectionRequest()
        {
            // for ORM
        }

        protected ConnectionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, CreationDate creationDate)
        {
            this.Id = id;
            this.ConnectionRequestStatus = status;
            this.PlayerSender = playerSender;
            this.PlayerReceiver = playerReceiver;
            this.Text = text;
            this.CreationDate = creationDate;
        }

        protected ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, Player playerSender, Player playerRecever, TextBox text)
        {
            this.ConnectionRequestStatus = connectionRequestStatus;
            this.PlayerSender = playerSender;
            this.PlayerReceiver = playerRecever;
            this.Text = text;
            this.CreationDate = new();
        }

        public void ChangeStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            this.ConnectionRequestStatus = connectionRequestStatus;
        }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}