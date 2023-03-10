using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.posts.domain.reaction;

namespace SocialNetwork.infrastructure.persistence.posts.reaction
{
    internal class ReactionEntityTypeConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reaction");
            builder.HasKey(b => b.Id);

            builder.OwnsOne(reaction => reaction.ReactionValue, reactionValue =>
            {
                reactionValue.Property("Reaction");
            });

            builder.OwnsOne(reaction => reaction.CreationDate, creationDate =>
            {
                creationDate.Property("Date");
            });
        }
    }
}