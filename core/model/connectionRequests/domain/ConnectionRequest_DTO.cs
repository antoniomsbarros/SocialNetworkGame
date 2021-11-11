
using System;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class ConnectionDto
    {
        public string Id { get; set; }
        
        public string ConnectionRequestStatus { get; set; }

        public string PlayerSender { get; set; }
        
        public string PlayerReceiver { get; set; }
        
        public string Text { get; set; }
        
        public string CreationDate { get; set; }

        public ConnectionDto(string id, string connectionRequestStatus, string playerSender, string playerReceiver, string text, string creationDate)
        {
            Id = id;
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = creationDate;
        }
    }
}