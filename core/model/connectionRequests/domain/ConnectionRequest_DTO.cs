
using System;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class ConnectionDto
    {
        public Guid Id { get; set; }
        
        public string ConnectionRequestStatus { get; set; }

        public string PlayerSender { get; set; }
        
        public string PlayerReceiver { get; set; }
        
        public string Text { get; set; }
        
        public string CreationDate { get; set; }
        
    }
}