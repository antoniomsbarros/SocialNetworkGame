using System.Collections.Generic;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class CreatingIntroductionConnectionDTO
    {
        public string ConnectionRequestStatus;

        public string PlayerSender;

        public string PlayerReceiver;

        public string Text;

        public string TextIntroduction;

        public string PlayerIntroduction;

        public string IntroductionStatus;

        public int ConnectionStrenght;
        public List<string> Tags { get; set; }

        public CreatingIntroductionConnectionDTO(string textIntroduction, string playerIntroduction, string introductionStatus,
             string connectionRequestStatus, string playerSender, string playerReceiver, string text,
             int connectionStrenght, List<string> tags)
        {
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            ConnectionStrenght = connectionStrenght;
            Tags = tags;
        }
    }
}