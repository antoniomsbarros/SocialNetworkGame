using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using SocialNetwork.core.model.relationships.domain;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class DirectRequest : ConnectionRequest, IDTOable<DirectRequestDto>
    {
        protected DirectRequest()
        {
            // for ORM
        }

        protected DirectRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, CreationDate creationDate,
            ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
            : base(id, status, playerSender, playerReceiver, text, creationDate, connectionStrengthConf, tagsConf)
        {
        }

        public DirectRequest(PlayerId playerSender, PlayerId playerReceiver, TextBox text,
            ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
            : base(playerSender, playerReceiver, text, connectionStrengthConf, tagsConf)
        {
        }

        public DirectRequestDto ToDto()
        {
            return new DirectRequestDto(
                Id.Value, ConnectionRequestStatus.CurrentStatus, PlayerSender.Value, PlayerReceiver.Value,

                Text.Content, CreationDate.Date,ConnectionStrengthConf.Strength, TagsConf.ConvertAll(tag => tag.Value));

        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(DirectRequest))
                return false;

            DirectRequest otherDirectRequest = (DirectRequest) obj;

            return otherDirectRequest.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}