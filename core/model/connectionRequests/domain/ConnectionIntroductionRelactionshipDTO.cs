﻿using System.Collections.Generic;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.connectionRequests.domain
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

        public int ConnectionStrenght;

        public List<string> Tags;

        public ConnectionIntroductionRelactionshipDTO(string id, string connectionRequestStatus, string playerSender, 
            string playerReceiver, string text, string creationDate, string textIntroduction, string playerIntroduction,
            string introductionStatus, int connectionStrenght, List<string> tags)
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
            ConnectionStrenght = connectionStrenght;
            Tags = tags;
        }
    }
}