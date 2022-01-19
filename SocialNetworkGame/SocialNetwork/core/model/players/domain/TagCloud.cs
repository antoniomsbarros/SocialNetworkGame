using System;
using System.Collections.Generic;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class TagCloud : IValueObject
    {
        public List<string> Tag{get;}

        public double Percentage{get;}

        public TagCloud(List<string> tag, double percentage)
        {
            this.Tag = tag;
            this.Percentage = percentage;
        }
        
        public static TagCloud ValueOf(List<string> tag, double percentage)
        {
            return new(tag, percentage);
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(Tag, Percentage);
        }
    }
}