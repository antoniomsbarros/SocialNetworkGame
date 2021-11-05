using System.Collections.Generic;
using System;

using LEI_21s5_3dg_41.Domain.Players;
using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domzain.Players
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