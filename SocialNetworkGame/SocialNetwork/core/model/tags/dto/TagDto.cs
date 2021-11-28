using System;

namespace SocialNetwork.core.model.tags.dto
{
    public class TagDto
    {
        public string name;
        public DateTime creationDate;

        public TagDto()
        {
            // empty
        }

        public TagDto(string name, DateTime creationDate)
        {
            this.name = name;
            this.creationDate = creationDate;
        }
    }
}