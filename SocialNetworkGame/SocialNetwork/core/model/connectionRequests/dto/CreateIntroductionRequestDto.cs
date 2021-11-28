using System.Collections.Generic;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class CreateIntroductionRequestDto
    {
        public string PlayerSender;

        public string PlayerReceiver;

        public string Text;

        public string TextIntroduction;

        public string PlayerIntroduction;

        public int ConnectionStrength;
        public List<string> Tags { get; set; }

        public CreateIntroductionRequestDto()
        {
            // Empty
        }

        public CreateIntroductionRequestDto(string playerSender, string playerReceiver, string text,
            string textIntroduction, string playerIntroduction, int connectionStrength, List<string> tags)
        {
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            ConnectionStrength = connectionStrength;
            Tags = tags;
        }
    }
}