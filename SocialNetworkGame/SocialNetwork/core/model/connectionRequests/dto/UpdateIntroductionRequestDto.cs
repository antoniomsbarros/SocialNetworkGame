using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class UpdateIntroductionRequestDto
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string TextIntroduction { get; set; }

        public ConnectionRequestStatusEnum ConnectionRequestStatus { get; set; }

        public ConnectionRequestStatusEnum IntroductionStatus { get; set; }

        public UpdateIntroductionRequestDto()
        {
            // Empty
        }
    }
}