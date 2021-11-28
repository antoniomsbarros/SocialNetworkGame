namespace SocialNetwork.core.model.tags.dto
{
    public class CreateTagDto
    {
        public string tagName;

        public CreateTagDto()
        {
        }

        public CreateTagDto(string tagName)
        {
            this.tagName = tagName;
        }
    }
}