
namespace SocialNetwork.core.model.relationships.dto
{
    public class PlayerFriendsDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string FacebookProfile { get; set; }
        public string LinkedinProfile { get; set; }
        public string EmocionalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public PlayerFriendsDTO(string name, string email, string facebookProfile, string linkedinProfile, string emocionalStatus, string phoneNumber)
        {
            Name = name;
            Email = email;
            FacebookProfile = facebookProfile;
            LinkedinProfile = linkedinProfile;
            EmocionalStatus = emocionalStatus;
            PhoneNumber = phoneNumber;
        }
    }
}