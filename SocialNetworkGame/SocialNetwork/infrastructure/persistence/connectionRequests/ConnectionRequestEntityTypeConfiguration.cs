using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.model.connectionRequests.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.core.model.relationships.domain;

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
                text.Property("Text");
            });

            builder.OwnsOne(request => request.ConnectionRequestStatus,
                connectionRequestStatus =>
                {
                    connectionRequestStatus.Property("CurrentStatus");
                });
            
            builder.OwnsOne(request => request.ConnectionStrengthConf,
                ConnectionStrenghtsender =>
                {
                    ConnectionStrenghtsender.Property(c=> c.Strength);
                });
           
            builder.OwnsMany(request => request.TagsConf, tag =>
            {
                tag.Property("Name");
            });
        }
    }
}
