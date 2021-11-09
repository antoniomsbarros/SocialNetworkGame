using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.missions.domain;

namespace SocialNetwork.infrastructure.missions
{
    internal class MissionEntityTypeConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.ToTable("Mission");
            builder.HasKey(b => b.Id);
        }
    }
}