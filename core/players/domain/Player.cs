using System.Collections.Generic;
using SocialNetwork.core.missions.domain;
using SocialNetwork.core.relationships.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    public class Player : Entity<PlayerId>, IAggregateRoot
    {
        public Email Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public FacebookProfile FacebookProfile { get; private set; }

        public LinkedinProfile LinkedinProfile { get; private set; }

        public DateOfBirth DateOfBirth { get; private set; }

        public Profile Profile { get; private set; }

        public List<Mission> Missions { get; private set; }

        public List<RelationShip> RelationShips { get; private set; }

    }
}