using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.infrastructure.persistence.players
{
    internal class PlayerEntityTypeConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");


            builder.OwnsMany(player => player.Missions, mission =>
            {
                mission.Property("Id");
            });

            builder.OwnsMany(player => player.RelationShips, relationship =>
            {
                relationship.Property("Id");
            });


            builder.HasKey(b => b.Id);
            builder.OwnsOne(player => player.Email, email =>
            {
                email.Property("EmailAddress");
            });
            builder.OwnsOne(player => player.PhoneNumber, number =>
            {
                number.Property("Number");
            });

            builder.OwnsOne(player => player.DateOfBirth, dateOfBirth =>
            {
                dateOfBirth.Property("Date");
            });

            builder.OwnsOne(player => player.FacebookProfile, facebookProfile =>
            {
                facebookProfile.Property("FacebookProfileLink");
            });

            builder.OwnsOne(player => player.LinkedinProfile, facebookProfile =>
            {
                facebookProfile.Property("LinkedinProfileLink");
            });


        }
    }
}