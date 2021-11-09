using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.core.shared
{
    [Owned]
    public class TextBox : IValueObject
    {
        public string text { get; }

        protected TextBox()
        {
            // for ORM
        }
        public TextBox(string text)
        {
            if (IsTextBoxValid(text))
            {
                this.text = text;
            }
            else if (IsTextBoxValid(text))
                throw new BusinessRuleValidationException("Text invalid");
        }

        public static bool IsTextBoxValid(string text)
        {
            return text.Length > 0;
        }
    }
}
