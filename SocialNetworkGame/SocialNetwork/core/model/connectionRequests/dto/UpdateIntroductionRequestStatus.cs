using SocialNetwork.core.model.connectionRequests.domain;

namespace SocialNetwork.core.model.connectionRequests.dto
{
    public class UpdateIntroductionRequestStatus
    {
        public string id;
        public ConnectionRequestStatusEnum newStatus;

        public UpdateIntroductionRequestStatus()
        {
            // empty
        }
    }
}