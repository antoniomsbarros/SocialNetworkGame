using System;

namespace SocialNetwork.core.model.shared
{
    public class Tag : IValueObject
    {
        private static readonly int minCaract = 1;
        private static readonly int maxCaract = 255;

        public string Name { get; }

        protected Tag()
        {
            // for ORM
        }

        public Tag(string tagName)
        {
            if (IsValid(tagName))
                this.Name = tagName;
            else
                throw new BusinessRuleValidationException(
                    $"The name of the Tag must have between {minCaract} and {maxCaract} characters");
        }

        public static bool IsValid(string tagName)
        {
            return (tagName.Length >= minCaract && tagName.Length <= maxCaract);
        }

        public static Tag ValueOf(string name)
        {
            return new(name);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Tag))
                return false;

            Tag otherTag = (Tag) obj;

            return otherTag.Name.Trim().ToLower().Equals(this.Name.Trim().ToLower());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}