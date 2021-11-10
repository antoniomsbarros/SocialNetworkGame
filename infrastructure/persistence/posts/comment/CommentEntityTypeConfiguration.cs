using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.posts.domain.comment;

namespace SocialNetwork.infrastructure.persistence.posts.comment
{
    internal class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(b => b.Id);
            builder.OwnsOne(comment => comment.CreationDate, creationDate =>
            {
                creationDate.Property("Date");
            });
            builder.OwnsOne(comment => comment.CommentText, commentText =>
            {
                commentText.Property("Text");
            });
        }
    }
}