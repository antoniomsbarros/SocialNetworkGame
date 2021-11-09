using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;

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
        public IntroductionRequest(Player playerIdintroduction, TextBox textIntroduction, ConnectionRequestStatus connectionRequestStatus,
                                     Player playerSender, Player playerRecever, TextBox text, ConnectionRequestStatus introductionStatus)
            : base(connectionRequestStatus, playerSender, playerRecever, text)
        {
            this.PlayerIntroduction = playerIdintroduction;
            this.TextIntroduction = textIntroduction;
            this.IntroductionStatus = introductionStatus;
        }

    }
}