using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.relationships.domain;

namespace SocialNetwork.infrastructure.relationships
{
    internal class RelationShipEntityTypeConfiguration : IEntityTypeConfiguration<RelationShip>
    {
        public void Configure(EntityTypeBuilder<RelationShip> builder)
        {
            builder.ToTable("Relationship");
            builder.HasKey(b => b.Id);
        }
    }
}