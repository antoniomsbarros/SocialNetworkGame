namespace lapr5_3dg.DTO
{
    public class ConnectionStrenghtDto
    {
        public int ConnectionId { get; set; }
        public ConnectionStrenghtDto(int connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}