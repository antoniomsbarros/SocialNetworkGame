namespace SocialNetwork.core.model.tags.dto
{
    public class TagCloudDto
    {
        public string tag;
        public string name;
        public double percentage;
      

        public TagCloudDto()
        {
            // empty
        }

        public TagCloudDto(string tag, string name, double percentage)
        {
            this.tag = tag;
            this.tag = name;
            this.percentage = percentage;
        }
    }
}