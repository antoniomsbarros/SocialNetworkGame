using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.players.domain;

namespace SocialNetwork.infrastructure.persistence.players
{
    internal class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(b => b.Id);
            builder.OwnsOne(profile => profile.Name, name =>
            {
                name.Property("ShortName");
                name.Property("FullName");
            });
            builder.OwnsMany(profile => profile.TagsList, tag =>
            {
                tag.Property("Name");
            });
        }
    }
}