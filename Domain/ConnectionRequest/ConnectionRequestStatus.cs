using LEI_21s5_3dg_41.Domain.Shared;
namespace LEI_21s5_3dg_41.Domain.ConnectionRequest{
    public enum ConnectionRequestStatusEnum{
approved, 
rejected, 
hold
}
public class ConnectionRequestStatus: IValueObject{

public ConnectionRequestStatusEnum CurrentStatus { get; }

    public ConnectionRequestStatus(ConnectionRequestStatusEnum Status){
        this.CurrentStatus=Status;
    }

}

}