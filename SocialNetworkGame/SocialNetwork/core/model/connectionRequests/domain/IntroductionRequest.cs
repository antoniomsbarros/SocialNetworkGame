using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class IntroductionRequest : ConnectionRequest, IDTOable<IntroductionRequestDto>
    {
        public TextBox TextIntroduction { get; private set; }
        public PlayerId PlayerIntroduction { get; private set; }

        public ConnectionRequestStatus IntroductionStatus { get; private set; }

        protected IntroductionRequest()
        {
            // for ORM
        }

        protected IntroductionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, CreationDate creationDate,
            TextBox textIntroduction, PlayerId playerIntroduction, ConnectionRequestStatus introductionStatus,
            ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
            : base(id, status, playerSender, playerReceiver, text, creationDate, connectionStrengthConf, tagsConf)
        {
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
            TextIntroduction = textIntroduction;
        }

        public IntroductionRequest(ConnectionRequestStatus status, PlayerId playerSender, PlayerId playerReceiver,
            TextBox text, TextBox textIntroduction, PlayerId playerIntroduction,
            ConnectionRequestStatus introductionStatus,
            ConnectionStrength connectionStrengthConf, List<TagId> tagsConf)
            : base(status, playerSender, playerReceiver, text, connectionStrengthConf, tagsConf)
        {
            PlayerIntroduction = playerIntroduction;
            IntroductionStatus = introductionStatus;
            TextIntroduction = textIntroduction;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(IntroductionRequest))
                return false;

            IntroductionRequest otherIntroductionRequest = (IntroductionRequest) obj;

            return otherIntroductionRequest.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void ChangeIntroductionStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            IntroductionStatus = connectionRequestStatus;
        }

        public void ChangeTextIntroduction(TextBox textBox)
        {
            TextIntroduction = textBox;
        }

        public void ChangePlayerIntroduction(PlayerId playerId)
        {
            PlayerIntroduction = playerId;
        }

        public IntroductionRequestDto ToDto()
        {
            return new IntroductionRequestDto(Id.Value, ConnectionRequestStatus.CurrentStatus, PlayerSender.Value,
                PlayerReceiver.Value, Text.Content, CreationDate.Date, 
                TextIntroduction.Content, PlayerIntroduction.Value,IntroductionStatus.CurrentStatus,ConnectionStrengthConf.Strength, TagsConf.ConvertAll(tag => tag.Value));
        }
    }
}