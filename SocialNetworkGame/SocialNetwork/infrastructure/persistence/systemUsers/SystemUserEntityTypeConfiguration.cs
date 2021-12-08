using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.systemUsers.domain;

namespace SocialNetwork.infrastructure.persistence.systemUsers
{
    public class SystemUserEntityTypeConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUser");
            builder.HasKey(b => b.Id);

            builder.OwnsOne(b => b.Password, p => 
                { p.Property("Value"); });
        }
    }
}