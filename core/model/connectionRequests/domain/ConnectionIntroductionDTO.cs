namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class ConnectionIntroductionDTO
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

        public ConnectionIntroductionDTO(string textIntroduction, string playerIntroduction, string introductionStatus, 
            string id, string connectionRequestStatus, string playerSender, string playerReceiver, string text, 
            string creationDate)
        {
            TextIntroduction = textIntroduction;
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
            Id = id;
            ConnectionRequestStatus = connectionRequestStatus;
            PlayerSender = playerSender;
            PlayerReceiver = playerReceiver;
            Text = text;
            CreationDate = creationDate;
        }
    }
}