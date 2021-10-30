using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Player;
namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
    public class IntroductionRequest: Entity<IntroductionRequestId>
    {
        public ConnectionRequestId connectionRequestId  { get;  private set; }
        
        public string text { get;  private set; }
        public PlayerId playerIdaproved { get;  private set; }
        public IntroductionRequest (ConnectionRequestId connectionRequestId, PlayerId playerId, string text){
            this.connectionRequestId=connectionRequestId;
            this.playerIdaproved=playerId;
            this.text=text;
        }
    }
}