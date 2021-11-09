using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.posts.domain.reaction;

namespace SocialNetwork.infrastructure.posts.reaction
{
    internal class ReactionEntityTypeConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reaction");
            builder.HasKey(b => b.Id);
        }
    }
}