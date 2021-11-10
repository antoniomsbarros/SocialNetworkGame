using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.relationships.domain;

namespace SocialNetwork.infrastructure.persistence.relationships
{
    internal class RelationShipEntityTypeConfiguration : IEntityTypeConfiguration<RelationShip>
    {
        public void Configure(EntityTypeBuilder<RelationShip> builder)
        {
            builder.ToTable("Relationship");
            builder.HasKey(b => b.Id);
            builder.OwnsMany(relationship => relationship.TagsList, tag =>
            {
                tag.Property("Name");
            });

            builder.OwnsOne(relationship => relationship.ConnectionStrenght,
                connectionStrength =>
                {
                    connectionStrength.Property(c => c.Strenght);
                });

        }
    }
}