using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.connectionRequests.domain
{
    public class IntroductionRequest : ConnectionRequest
    {
        public TextBox TextIntroduction { get; private set; }
        public Player PlayerIntroduction { get; private set; }
        public ConnectionRequestStatus IntroductionStatus { get; private set; }
        protected IntroductionRequest() : base()
        {
            // for ORM
        }

        protected IntroductionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, CreationDate creationDate, TextBox textIntroduction, Player playerIntroduction,
            ConnectionRequestStatus introductionStatus)
             : base(id, status, playerSender, playerReceiver, text, creationDate)
        {
            this.TextIntroduction = textIntroduction;
            this.PlayerIntroduction = playerIntroduction;
            this.IntroductionStatus = introductionStatus;
        }

        protected IntroductionRequest(ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, TextBox textIntroduction, Player playerIntroduction,
            ConnectionRequestStatus introductionStatus)
             : base(status, playerSender, playerReceiver, text)
        {
            this.TextIntroduction = textIntroduction;
            this.PlayerIntroduction = playerIntroduction;
            this.IntroductionStatus = introductionStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(IntroductionRequest))
                return false;

            IntroductionRequest otherIntroductionRequest = (IntroductionRequest)obj;

            return otherIntroductionRequest.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}