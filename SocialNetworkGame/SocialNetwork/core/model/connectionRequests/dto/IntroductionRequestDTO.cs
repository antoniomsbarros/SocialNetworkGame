namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class IntroductionRequestDTO //TODO MISSING Information about the abstract class ConnectionRequest 
    {
        public string Id;

        public string TextIntroduction;

        public string PlayerIntroduction;

        public string IntroductionStatus;

        public IntroductionRequestDTO(string id, string textIntroduction, string playerIntroduction,
            string introductionStatus)
        {
            Id = id;
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
        }
    }
}