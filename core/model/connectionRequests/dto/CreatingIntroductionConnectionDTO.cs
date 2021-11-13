namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class CreatingIntroductionConnectionDTO
    {
        public string ConnectionRequestStatus;

        public string PlayerSender;

        public string PlayerReceiver;

        public string Text;

        public string CreationDate;
        
        public string TextIntroduction;

        public string PlayerIntroduction;

        public string IntroductionStatus;

        public CreatingIntroductionConnectionDTO(string connectionRequestStatus, string playerSender, 
            string playerReceiver, string text, string creationDate, string textIntroduction, 
            string playerIntroduction, string introductionStatus)
        {
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = creationDate;
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
        }
    }
}