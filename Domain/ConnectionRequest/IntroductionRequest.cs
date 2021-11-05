using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Players;
namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
    public class IntroductionRequest: ConnectionRequest
    {
        public Text textIntroduction { get;  private set; }
        public PlayerId playerIdintroduction { get;  private set; }

        public ConnectionRequestStatus introductionStatus { get;  private set; }
        public IntroductionRequest(){

        }
        public IntroductionRequest ( PlayerId playerIdintroduction, Text textIntroduction, ConnectionRequestStatus connectionRequestStatus,
                                     PlayerId playerSender, PlayerId playerRecever, Text text, ConnectionRequestStatus introductionStatus){
            this.connectionRequestStatus=connectionRequestStatus;
            this.playerIdintroduction=playerIdintroduction;
            this.textIntroduction=textIntroduction;
            this.introductionStatus=introductionStatus;
            }

        
    }
}