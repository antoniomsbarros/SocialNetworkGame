using SocialNetwork.core.model.shared;
using System;
using System.Text.RegularExpressions;

namespace SocialNetwork.core.model.tags.domain
{
    public class TagName : IValueObject
    {

        private const string TagRegex = "^[a-zA-Z0-9 ]*$";

        public string Name { get; }

        protected TagName()
        {
            // for ORM
        }

        public TagName(string Name)
        {
            if (TagNameValid(Name))
            {
                this.Name = Name;
            }
            else if (TagNameValid(Name))
                throw new BusinessRuleValidationException("Tag name invalid");
        }

        public static bool TagNameValid(string Name)
        {
            return new Regex(TagRegex).IsMatch(Name)
                   && Name.Length > 0;
        }

        public static TagName ValueOf(string Name)
        {
            return new(Name);
        }

        public override bool Equals(object obj)
        {
            return obj is TagName name &&
                   Name == name.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}