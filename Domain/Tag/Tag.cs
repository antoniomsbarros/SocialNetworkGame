using System;
using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Tag
{
    public class Tag : Entity<TagId>, IAggregateRoot
    {
        public TagName Name { get; private set; }

        public Tag(TagName name)
        {
            this.Id = new TagId(Guid.NewGuid());
            this.Name = name;
        }
    }
}