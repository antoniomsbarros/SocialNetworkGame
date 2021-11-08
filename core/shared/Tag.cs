namespace SocialNetwork.core.shared
{
    public class Tag : IValueObject
    {

        public string Name { get; }

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
