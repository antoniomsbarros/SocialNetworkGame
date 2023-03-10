using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.posts.domain.post;

namespace SocialNetwork.infrastructure.persistence.posts.post
{
    internal class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(b => b.Id);
            builder.OwnsOne(post => post.CreationDate, creationDate =>
            {
                creationDate.Property("Date");
            });

            builder.OwnsMany(post => post.Tags, tag =>
            {
                tag.Property("Value");
            });

            builder.OwnsOne(post => post.PostText, postText =>
            {
                postText.Property("Content");
            });


        }
    }
}