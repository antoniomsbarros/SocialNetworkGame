using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.ConnectionRequest
{
    public class DirectRequest : Entity<DirectRequestId>
    {
        public ConnectionRequestId connectionRequestId  { get;  private set; }


        public DirectRequest (ConnectionRequestId connectionRequestId){
            this.connectionRequestId=connectionRequestId;
        }
    }
}