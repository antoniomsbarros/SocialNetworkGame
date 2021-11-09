﻿using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.missions.domain
{
    public enum MissionStatusEnum
    {
        Active,
        Canceled,
        Completed,
        In_progress,
        Suspended
    }

    [Owned]
    public class MissionStatus : IValueObject
    {
        public MissionStatusEnum CurrentStatus { get; }

        protected MissionStatus()
        {
            // for ORM
        }

        public MissionStatus(MissionStatusEnum status)
        {
            this.CurrentStatus = status;
        }

    }
}
