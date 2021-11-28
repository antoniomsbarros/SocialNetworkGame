using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public abstract class ConnectionRequestDto
    {
        public string Id { get; set; }

        public ConnectionRequestStatusEnum ConnectionRequestStatus { get; set; }

        public string PlayerSender { get; set; }

        public string PlayerReceiver { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public List<string> Tags { get; set; }

        public int ConnectionStrength { get; set; }

        public ConnectionRequestDto(string id, ConnectionRequestStatusEnum connectionRequestStatus, string playerSender,
            string playerReceiver, string text, DateTime creationDate, List<string> tags, int connectionStrength)
        {
            Id = id;
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = creationDate;
            Tags = tags;
            ConnectionStrength = connectionStrength;
        }
    }
}