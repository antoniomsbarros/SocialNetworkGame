using System;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class DirectRequestDTO : ConnectionRequestDTO
    {
        public DirectRequestDTO(string id, ConnectionRequestStatusEnum connectionRequestStatus, string playerSender,
            string playerReceiver,
            string text, DateTime creationDate) : base(id, connectionRequestStatus, playerSender, playerReceiver, text,
            creationDate)
        {
        }
    }
}