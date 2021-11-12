using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;
using SocialNetwork.core.model.relationships;
using System.Collections.Generic;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class IntroductionRequest : ConnectionRequest
    {
        public TextBox TextIntroduction { get; private set; }

        public PlayerId PlayerIntroduction { get; private set; }
        public ConnectionRequestStatus IntroductionStatus { get;  set; }
        protected IntroductionRequest() : base()
        {
            // for ORM
        }

        public IntroductionRequest(ConnectionRequestId id, ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, CreationDate creationDate, TextBox textIntroduction, Player playerIntroduction,
            ConnectionRequestStatus introductionStatus,ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
             : base(id, status, playerSender, playerReceiver, text, creationDate, connectionStrenghtsender, tags)
        {
            this.TextIntroduction = textIntroduction;
            this.PlayerIntroduction = playerIntroduction.Id;
            this.IntroductionStatus = introductionStatus;
        }

        public IntroductionRequest(ConnectionRequestStatus status,
            Player playerSender, Player playerReceiver, TextBox text, TextBox textIntroduction, Player playerIntroduction,
            ConnectionRequestStatus introductionStatus,ConnectionStrenght connectionStrenghtsender, List<Tag> tags)
             : base(status, playerSender, playerReceiver, text, connectionStrenghtsender, tags)
        {
            this.TextIntroduction = textIntroduction;
            this.PlayerIntroduction = playerIntroduction.Id;
            this.IntroductionStatus = introductionStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(IntroductionRequest))
                return false;

            IntroductionRequest otherIntroductionRequest = (IntroductionRequest)obj;

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

        public ConnectionIntroductionDTO Dto()
        {
           /* return new IntroductionRequest_DTO(this.TextIntroduction.ToString(), this.PlayerIntroduction.AsString(), this.IntroductionStatus.ToString(),
                this.Id.AsString(), this.ConnectionRequestStatus.ToString(), this.PlayerSender.ToString(), this.PlayerReceiver.ToString(), this.Text.ToString(),
                this.CreationDate.ToString());*/
           List<string> tagToDto = new List<string>();
           Tags.ForEach(tag =>tagToDto.Add(tag.Name) );
           return new ConnectionIntroductionDTO(this.TextIntroduction.ToString(), this.PlayerIntroduction.AsString(), this.IntroductionStatus.ToString(),
               this.Id.AsString(), this.ConnectionRequestStatus.ToString(), this.PlayerSender.ToString(), this.PlayerReceiver.ToString(), this.Text.ToString(),
               this.CreationDate.ToString(),ConnectionStrenghtsender.Strenght, tagToDto );
        }
    }
}