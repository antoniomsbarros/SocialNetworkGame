using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Post
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
