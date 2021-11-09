using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    public class DirectRequest : ConnectionRequest
    {
        protected DirectRequest() : base()
        {
            // for ORM
        }

        public DirectRequest(ConnectionRequestStatus connectionRequestStatus, Player playerSender, Player playerRecever, TextBox text)
            : base(connectionRequestStatus, playerSender, playerRecever, text)
        {
        }
    }
}