using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Players;
namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
    public class DirectRequest : ConnectionRequest
    {
        public DirectRequest (){
            
        }
        public DirectRequest (ConnectionRequestStatus connectionRequestStatus, PlayerId playerSender, PlayerId playerRecever, string text){
            this.connectionRequestStatus=connectionRequestStatus;
            this.playerSender=playerSender;
            this.playerRecever=playerRecever;
            this.text=text;
        }
    }
}