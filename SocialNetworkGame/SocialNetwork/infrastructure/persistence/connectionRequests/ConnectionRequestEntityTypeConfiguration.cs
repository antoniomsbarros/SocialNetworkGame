using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.infrastructure.persistence.connectionRequests
{
    internal class ConnectionRequestEntityTypeConfiguration : IEntityTypeConfiguration<ConnectionRequest>
    {
        public void Configure(EntityTypeBuilder<ConnectionRequest> builder)
        {
            builder.HasKey(b => b.Id);
            builder.OwnsOne(connectionRequest => connectionRequest.CreationDate, 
                creationDate =>
            {
                creationDate.Property("Date");
            });

            builder.OwnsOne(request => request.Text, text =>
            {
                text.Property("Content");
            });

            builder.OwnsOne(request => request.ConnectionRequestStatus,
                connectionRequestStatus =>
                {
                    connectionRequestStatus.Property("CurrentStatus");
                });
            
            builder.OwnsOne(request => request.ConnectionStrengthConf,
                connectionStrengthConf =>
                {
                    connectionStrengthConf.Property(c=> c.Strength);
                });
           
            builder.OwnsMany(request => request.TagsConf, tag =>
            {
                tag.Property("Value");
            });
        }
    }
}
