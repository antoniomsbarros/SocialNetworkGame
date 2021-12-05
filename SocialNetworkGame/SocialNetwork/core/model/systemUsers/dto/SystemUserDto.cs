namespace SocialNetwork.core.model.systemUsers.dto
{
    public class SystemUserDto
    {
        public string username;
        public string password;

        public SystemUserDto()
        {
            // empty
        }

        public SystemUserDto(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}