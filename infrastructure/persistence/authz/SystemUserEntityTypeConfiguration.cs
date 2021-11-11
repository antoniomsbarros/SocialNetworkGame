using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.infrastructure.authz.domain.model;

namespace SocialNetwork.infrastructure.persistence.authz
{
    public class SystemUserEntityTypeConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(b => b.Username);
        }
    }
}