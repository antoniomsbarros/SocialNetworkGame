using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Players;
namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
    public class IntroductionRequest: ConnectionRequest
    {
        public string textIntroduction { get;  private set; }
        public PlayerId playerIdintroduction { get;  private set; }

        public IntroductionRequest(){

        }
        public IntroductionRequest ( PlayerId playerIdintroduction, string textIntroduction, ConnectionRequestStatus connectionRequestStatus,
                                     PlayerId playerSender, PlayerId playerRecever, string text){
            this.connectionRequestStatus=connectionRequestStatus;
            this.playerIdintroduction=playerIdintroduction;
            this.textIntroduction=textIntroduction;
        }

        
    }
}