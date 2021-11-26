using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.infrastructure.persistence.relationships
{
    internal class RelationShipEntityTypeConfiguration : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.ToTable("Relationship");
            builder.HasKey(b => b.Id);
            builder.OwnsMany(relationship => relationship.TagsList, tag =>
            {
                tag.Property("Name");
            });

            builder.OwnsOne(relationship => relationship.ConnectionStrength,
                connectionStrength =>
                {
                    connectionStrength.Property(c => c.Strength);
                });
            builder.OwnsOne(relationship => relationship.PlayerDest,
                playerDest =>
                {
                    playerDest.Property(c => c.Value);
                });
            builder.OwnsOne(relationship => relationship.PlayerOrig,
                playerOrig =>
                {
                    playerOrig.Property(c => c.Value);
                });
        }
    }
}