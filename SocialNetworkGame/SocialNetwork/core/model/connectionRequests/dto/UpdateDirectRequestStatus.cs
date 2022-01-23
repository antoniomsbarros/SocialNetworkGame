using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class UpdateDirectRequestStatus
    {
        public string id;
        public ConnectionRequestStatusEnum newStatus;
        public string playerReceiverEmail;
        public string playerSenderEmail;
        public List<string> tags;

        public UpdateDirectRequestStatus()
        {
            // empty
        }

        public UpdateDirectRequestStatus(string id1, string newStatus1, string playerReceiverEmail, 
            string playerSenderEmail, List<string> tags)
        {
            ConnectionRequestStatusEnum statusEnum =
                (ConnectionRequestStatusEnum) Enum.Parse(typeof(ConnectionRequestStatusEnum),
                    newStatus1);
            id = id1;
            newStatus = new ConnectionRequestStatus(statusEnum).CurrentStatus;
            this.playerReceiverEmail = playerReceiverEmail;
            this.playerSenderEmail = playerSenderEmail;
            this.tags = tags;
        }
    }
}