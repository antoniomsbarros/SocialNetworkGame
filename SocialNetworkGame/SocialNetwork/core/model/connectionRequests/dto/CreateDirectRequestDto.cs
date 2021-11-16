using System.Collections.Generic;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class CreateDirectRequestDto
    {
        public string PlayerSender { get; set; } // email

        public string PlayerReceiver { get; set; } // email

        public string Text { get; set; }

        public int ConnectionStrength { get; set; }

        public List<string> Tags { get; set; }

        public CreateDirectRequestDto()
        {
            // empty
        }

        public CreateDirectRequestDto(string playerSender, string playerReceiver, string text, int
            connectionStrength, List<string> tags)
        {
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            Tags = new(tags);
        }
    }
}