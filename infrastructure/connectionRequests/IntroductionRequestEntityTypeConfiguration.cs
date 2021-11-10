using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.core.connectionRequests.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.infrastructure.connectionRequests
{
    internal class IntroductionRequestEntityTypeConfiguration : IEntityTypeConfiguration<IntroductionRequest>
    {
        public void Configure(EntityTypeBuilder<IntroductionRequest> builder)
        {
            builder.HasBaseType<ConnectionRequest>();
            builder.ToTable("IntroductionRequest");

            builder.OwnsOne(request => request.TextIntroduction, textIntroduction =>
            {
                textIntroduction.Property("Text");
            });

            builder.OwnsOne(request => request.IntroductionStatus,
                introductionStatus =>
                {
                    introductionStatus.Property("CurrentStatus");
                });
        }
    }
}
