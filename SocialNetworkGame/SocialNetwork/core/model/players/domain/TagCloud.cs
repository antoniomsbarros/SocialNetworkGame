using System;
using System.Collections.Generic;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class TagCloud : IValueObject
    {
        public string Tag{get;}

        public double Percentage{get;}

        public TagCloud(string tag, double percentage)
        {
            this.Tag = tag;
            this.Percentage = percentage;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(Tag, Percentage);
        }
    }
}