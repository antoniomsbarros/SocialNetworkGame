using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.connectionRequests.domain;

namespace SocialNetwork.infrastructure.connectionRequests
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