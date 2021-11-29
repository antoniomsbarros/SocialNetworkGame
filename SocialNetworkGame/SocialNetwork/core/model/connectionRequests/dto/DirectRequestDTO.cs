using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class DirectRequestDto : ConnectionRequestDto
    {
        public DirectRequestDto(string id, ConnectionRequestStatusEnum connectionRequestStatus, string playerSender,
            string playerReceiver, string text, DateTime creationDate,int ConnectionStrengthConf, List<string> tags)
            : base(id, connectionRequestStatus, playerSender, playerReceiver, text, creationDate, ConnectionStrengthConf,tags)
        {
        }
    }
}