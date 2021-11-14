using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class IntroductionRequest : ConnectionRequest, IDTOable<ConnectionIntroductionDTO>
    {
        public TextBox TextIntroduction { get; private set; }
        public PlayerId PlayerIntroduction { get; private set; }

        public ConnectionRequestStatus IntroductionStatus { get; private set; }

        protected IntroductionRequest() : base()
        {
            // for ORM
        }

        public IntroductionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, CreationDate creationDate,
            TextBox textIntroduction, PlayerId playerIntroduction,
            ConnectionRequestStatus introductionStatus, ConnectionStrenght connectionStrengthSender, List<Tag> tags)
            : base(id, status, playerSender, playerReceiver, text, creationDate, connectionStrengthSender, tags)
        {
            this.TextIntroduction = textIntroduction;
            this.PlayerIntroduction = playerIntroduction;
            this.IntroductionStatus = introductionStatus;
        }

        public IntroductionRequest(ConnectionRequestStatus status,
            PlayerId playerSender, PlayerId playerReceiver, TextBox text, TextBox textIntroduction,
            PlayerId playerIntroduction,
            ConnectionRequestStatus introductionStatus, ConnectionStrenght connectionStrengthSender, List<Tag> tags)
            : base(status, playerSender, playerReceiver, text, connectionStrengthSender, tags)
        {
            this.TextIntroduction = textIntroduction;
            this.PlayerIntroduction = playerIntroduction;
            this.IntroductionStatus = introductionStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(IntroductionRequest))
                return false;

            IntroductionRequest otherIntroductionRequest = (IntroductionRequest) obj;

            return otherIntroductionRequest.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

        public void ChangeIntroductionStatus(ConnectionRequestStatus connectionRequestStatus)
        {
            this.IntroductionStatus = connectionRequestStatus;
        }

        public void ChangeTextIntroduction(TextBox textBox)
        {
            TextIntroduction = textBox;
        }

        public void ChangePlayerIntroduction(PlayerId playerId)
        {
            PlayerIntroduction = playerId;
        }


        public ConnectionIntroductionDTO ToDto()
        {
            /* return new IntroductionRequest_DTO(this.TextIntroduction.ToString(), this.PlayerIntroduction.AsString(), this.IntroductionStatus.ToString(),
                 this.Id.AsString(), this.ConnectionRequestStatus.ToString(), this.PlayerSender.ToString(), this.PlayerReceiver.ToString(), this.Text.ToString(),
                 this.CreationDate.ToString());*/

            List<string> tagToDto = new List<string>();
            Tags.ForEach(tag => tagToDto.Add(tag.Name));
            return new ConnectionIntroductionDTO(this.TextIntroduction.ToString(), this.PlayerIntroduction.AsString(),
                this.IntroductionStatus.ToString(),
                this.Id.AsString(), this.ConnectionRequestStatus.ToString(), this.PlayerSender.ToString(),
                this.PlayerReceiver.ToString(), this.Text.ToString(),
                this.CreationDate.ToString(), ConnectionStrengthSender.Strenght, tagToDto);
        }
    }
}