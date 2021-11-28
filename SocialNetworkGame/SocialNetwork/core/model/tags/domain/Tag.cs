using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;

namespace SocialNetwork.core.model.tags.domain
{
    public class Tag : Entity<TagId>, IAggregateRoot
    {

        public TagName TagName { get; private set; }

        public CreationDate CreationDate { get; private set; }

        public Tag(TagId tagId, TagName tagName, CreationDate creationDate)
        {
            this.Id = tagId;
            this.TagName = tagName;
            this.CreationDate = creationDate;
        }

        public Tag(TagName tagName)
        {
            this.Id = new TagId(Guid.NewGuid());
            this.TagName = tagName;
            this.CreationDate = new();
        }

        public void ChangeTagName(TagName newName)
        {
            this.TagName = newName;
        }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   EqualityComparer<TagId>.Default.Equals(Id, tag.Id) &&
                   EqualityComparer<TagName>.Default.Equals(TagName, tag.TagName) &&
                   EqualityComparer<CreationDate>.Default.Equals(CreationDate, tag.CreationDate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TagName, CreationDate);
        }
    }
}
