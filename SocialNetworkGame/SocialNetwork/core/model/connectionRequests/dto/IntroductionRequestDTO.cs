using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class IntroductionRequestDto : ConnectionRequestDto
    {
        public string TextIntroduction { get; set; }

        public string PlayerIntroduction { get; set; }

        public ConnectionRequestStatusEnum IntroductionStatus { get; set; }

        public IntroductionRequestDto(string id, ConnectionRequestStatusEnum connectionRequestStatus,
            string playerSender, string playerReceiver, string text, DateTime creationDate, string textIntroduction,
            string playerIntroduction, ConnectionRequestStatusEnum introductionStatus, List<string> tags)
            : base(id, connectionRequestStatus, playerSender, playerReceiver, text, creationDate, tags)
        {
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
        }
    }
}