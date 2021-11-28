using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.infrastructure.persistence.tags
{
    public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.HasKey(b => b.Id);
            
            builder.OwnsOne(tag => tag.TagName, tagName =>
            {
                tagName.Property("Value").IsRequired();
                tagName.HasIndex("Value").IsUnique();
            });

            builder.OwnsOne(tag => tag.CreationDate, creationDate =>
            {
                creationDate.Property("Date");
            });
        }
    }
}