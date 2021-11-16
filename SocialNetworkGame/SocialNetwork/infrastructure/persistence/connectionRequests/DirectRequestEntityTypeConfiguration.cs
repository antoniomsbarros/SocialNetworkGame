using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
{
    internal class DirectRequestEntityTypeConfiguration : IEntityTypeConfiguration<DirectRequest>
    {
        public void Configure(EntityTypeBuilder<DirectRequest> builder)
        {
            builder.HasBaseType<ConnectionRequest>();
            builder.ToTable("DirectRequest");
        }
    }
}