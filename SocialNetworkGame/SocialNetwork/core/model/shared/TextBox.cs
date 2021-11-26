using System;

namespace SocialNetwork.core.model.shared
{
    public class TextBox : IValueObject
    {
        private const int CharacterLimit = 10000;
        public string Content { get; }

        protected TextBox()
        {
            // for ORM
        }

        public TextBox(string content)
        {
            if (IsValid(content))
                Content = content;
            else
                throw new BusinessRuleValidationException("Content of the Text box invalid");
        }

        public static bool IsValid(string text)
        {
            return text.Trim().Length is > 0 and <= CharacterLimit;
        }

        public static TextBox ValueOf(string content)
        {
            return new(content);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj.GetType() != typeof(TextBox))
                return false;

            TextBox otherTextBox = (TextBox) obj;

            return otherTextBox.Content.Trim().ToLower().Equals(
                Content.Trim().ToLower());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Content);
        }
    }
}