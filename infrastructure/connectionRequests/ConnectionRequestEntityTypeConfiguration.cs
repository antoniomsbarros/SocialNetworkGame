using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.connectionRequests.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.infrastructure.connectionRequests
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
                text.Property("Text");
            });

            builder.OwnsOne(request => request.ConnectionRequestStatus,
                connectionRequestStatus =>
                {
                    connectionRequestStatus.Property("CurrentStatus");
                });
        }
    }
}
