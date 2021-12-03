using System;

namespace SocialNetwork.core.model.tags.dto
{
    public class TagDto
    {
        public string id;
        public string name;
        public string creationDate;

        public TagDto()
        {
            // empty
        }

        public TagDto(string id, string name, DateTime creationDate)
        {
            this.id = id;
            this.name = name;
            this.creationDate = creationDate.ToString();
        }
    }
}