using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.tags.domain
{
    public class TagName : IValueObject
    {
        private static readonly int minCaract = 1;
        private static readonly int maxCaract = 255;

        public string Value { get; }

        protected TagName()
        {
            // for ORM
        }

        public TagName(string tagValue)
        {
            if (IsValid(tagValue))
                this.Value = tagValue;
            else
                throw new BusinessRuleValidationException(
                    $"The name of the Tag must have between {minCaract} and {maxCaract} characters");
        }

        public static bool IsValid(string tagName)
        {
            return (tagName.Length >= minCaract && tagName.Length <= maxCaract);
        }

        public static TagName ValueOf(string name)
        {
            return new(name);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Tag))
                return false;

            TagName otherTag = (TagName) obj;

            return otherTag.Value.Trim().ToLower().Equals(Value.Trim().ToLower());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}