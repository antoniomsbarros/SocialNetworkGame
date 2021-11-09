using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.core.shared
{
    [Owned]
    public class Tag : IValueObject
    {

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
                throw new BusinessRuleValidationException("Tag name invalid");
        }

        public static bool IsValid(string tagName)
        {
            return tagName.Length > 0;
        }

    }
}
