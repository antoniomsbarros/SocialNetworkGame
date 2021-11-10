using System;

namespace SocialNetwork.core.shared
{
    public class TextBox : IValueObject
    {

        public string Text { get; }

        protected TextBox()
        {
            // for ORM
        }

        public TextBox(string text)
        {
            if (IsValid(text))
                this.Text = text;
            else
                throw new BusinessRuleValidationException("Text of TextBox invalid");
        }

        public static bool IsValid(string text)
        {
            return text.Trim().Length > 0;
        }

        public static TextBox ValueOf(string text)
        {
            return new(text);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj.GetType() != typeof(TextBox))
                return false;

            TextBox otherTextBox = (TextBox)obj;

            return otherTextBox.Text.Trim().ToLower().Equals(
                this.Text.Trim().ToLower());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Text);
        }
    }
}
