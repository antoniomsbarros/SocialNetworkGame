namespace SocialNetwork.core.model.systemUsers.dto
{
    public class SystemUserCreatedDto
    {
        public string username;

        protected SystemUserCreatedDto()
        {
            // empty
        }

        public SystemUserCreatedDto(string username)
        {
            this.username = username;
        }
    }
}