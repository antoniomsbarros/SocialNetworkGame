using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class ConnectionIntroductionRelactionshipDTO
    {
        public string Id;

        public string ConnectionRequestStatus;

        public string PlayerSender;

        public string PlayerReceiver;

        public string Text;

        public string CreationDate;
        
        public string TextIntroduction;

        public string PlayerIntroduction;

        public string IntroductionStatus;

        public int ConnectionStrenghtAproval;

        public List<string> Tags;
        
        public ConnectionIntroductionRelactionshipDTO(string id, string connectionRequestStatus, string playerSender, 
            string playerReceiver, string text, string creationDate, string textIntroduction, string playerIntroduction,
            string introductionStatus, int connectionStrenghtAproval, List<string> tags)
        {
            Id = id;
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = creationDate;
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
            ConnectionStrenghtAproval = connectionStrenghtAproval;
            Tags = tags;
        }
        
    }
}