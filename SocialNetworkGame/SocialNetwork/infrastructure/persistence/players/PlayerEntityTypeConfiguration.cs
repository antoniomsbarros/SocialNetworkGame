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

            builder.HasKey(b => b.Id);

            builder.OwnsOne(player => player.Email, email =>
            {
                email.Property("Address").IsRequired();
                email.HasIndex("Address").IsUnique();
            });

            builder.OwnsOne(player => player.PhoneNumber, number =>
            {
                number.Property("Number");
            });

            builder.OwnsOne(player => player.DateOfBirth, dateOfBirth =>
            {
                dateOfBirth.Property("Date");
            });

            builder.OwnsOne(player => player.FacebookProfile,
                facebookProfile =>
                {
                    facebookProfile.Property("FacebookProfileLink");
                });

            builder.OwnsOne(player => player.LinkedinProfile,
                linkedinProfile =>
                {
                    linkedinProfile.Property("LinkedinProfileLink");
                });

            builder.OwnsOne(player => player.Name, name =>
            {
                name.Property("ShortName");
                name.Property("FullName");
            });

            builder.OwnsOne(player => player.EmotionalStatus,
                emotionalStatus =>
                {
                    emotionalStatus.Property("CurrentEmotionalStatus");
                });

            builder.OwnsMany(player => player.TagsList, tagsList =>
            {
                tagsList.Property("Value");
            });
        }
    }
}