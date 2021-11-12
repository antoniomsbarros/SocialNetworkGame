namespace SocialNetwork.core.model.players.dto
{
    public class PlayerEmailDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public PlayerEmailDto(string email,string name)
        {
            Email = email;
            Name = name;
        }
    }
}
