using System;
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

        public UpdateIntroductionRequestStatus(string id1, string newStatus1)
        {
            ConnectionRequestStatusEnum statusEnum =
                (ConnectionRequestStatusEnum) Enum.Parse(typeof(ConnectionRequestStatusEnum),
                    newStatus1);
            this.id = id1;
            newStatus = new ConnectionRequestStatus(statusEnum).CurrentStatus;
        }
    }
}