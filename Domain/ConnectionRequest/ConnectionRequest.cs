using System;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Players;
namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
public enum ConnectionRequestStatus{
approved, 
rejected, 
hold
}

    public abstract class ConnectionRequest : Entity<ConnectionRequestId>, IAggregateRoot
    {
        public ConnectionRequestStatus connectionRequestStatus { get;   set; }

        public PlayerId playerSender { get;   set; }
         public PlayerId playerRecever { get;   set; }
        
        public string text { get;   set; }

public ConnectionRequest (){
    
}

        public ConnectionRequest(ConnectionRequestStatus connectionRequestStatus, PlayerId playerSender, PlayerId playerRecever, string text){
                this.connectionRequestStatus=connectionRequestStatus;
                this.playerSender=playerSender;
                this.playerRecever=playerRecever;
                this.text=text;
        }

        public void ChangeConnectionRequestStatus(ConnectionRequestStatus connectionRequestStatus){
            this.connectionRequestStatus=connectionRequestStatus;
        }
        
    }
}