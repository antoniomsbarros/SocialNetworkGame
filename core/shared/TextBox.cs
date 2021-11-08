namespace SocialNetwork.core.shared
{
    public class TextBox : IValueObject
    {
        public string text { get; }

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
