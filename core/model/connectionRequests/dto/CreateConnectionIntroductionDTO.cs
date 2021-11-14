using System.Collections.Generic;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class CreateConnectionIntroductionDTO
    {
        public string PlayerSender;

        public string PlayerReceiver;

        public string Text;

        public string TextIntroduction;

        public string PlayerIntroduction;

        public int ConnectionStrenght;
        public List<string> Tags { get; set; }

        public CreateConnectionIntroductionDTO(string playerSender, string playerReceiver, string text,
            string textIntroduction, string playerIntroduction, int connectionStrenght, List<string> tags)
        {
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            ConnectionStrenght = connectionStrenght;
            Tags = tags;
        }
    }
}