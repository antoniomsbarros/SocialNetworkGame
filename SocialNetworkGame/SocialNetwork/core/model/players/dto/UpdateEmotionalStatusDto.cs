using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.players.dto
{
    public class UpdateEmotionalStatusDto
    {
        public string id;
        public EmotionalStatusEnum newEmotionalStatus;

        public UpdateEmotionalStatusDto()
        {
            // empty
        }
    }
}