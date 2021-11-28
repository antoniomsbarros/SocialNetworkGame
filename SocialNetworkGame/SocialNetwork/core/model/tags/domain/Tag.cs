using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.tags.dto;

namespace SocialNetwork.core.model.tags.domain
{
    public class Tag : Entity<TagId>, IAggregateRoot, IDTOable<TagDto>
    {
        public TagName TagName { get; private set; }

        public CreationDate CreationDate { get; private set; }

        protected Tag()
        {
            // for ORM
        }

        protected Tag(TagId tagId, TagName tagName, CreationDate creationDate)
        {
            Id = tagId;
            TagName = tagName;
            CreationDate = creationDate;
        }

        public Tag(TagName tagName)
        {
            Id = new TagId(Guid.NewGuid());
            TagName = tagName;
            CreationDate = new();
        }

        public void ChangeName(TagName newName)
        {
            TagName = newName;
        }

        public TagDto ToDto()
        {
            return new TagDto(TagName.Value, CreationDate.Date);
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
            return HashCode.Combine(Id);
        }
    }
}