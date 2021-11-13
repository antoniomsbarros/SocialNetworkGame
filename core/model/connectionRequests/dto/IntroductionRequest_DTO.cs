using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class IntroductionRequest_DTO
    {
        public string Id;
        public string TextIntroduction;

        public string PlayerIntroduction;

        public string IntroductionStatus;

        public IntroductionRequest_DTO(string id,string textIntroduction, string playerIntroduction, 
            string introductionStatus)
        {
            Id = id;
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
        }
        
        
    }
}