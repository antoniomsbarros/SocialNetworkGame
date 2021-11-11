namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class IntroductionRequest_DTO
    {
        public string TextIntroduction;

        public string PlayerIntroduction;

        public string IntroductionStatus;

        public IntroductionRequest_DTO(string textIntroduction, string playerIntroduction, string introductionStatus)
        {
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
        }
        
        
    }
}