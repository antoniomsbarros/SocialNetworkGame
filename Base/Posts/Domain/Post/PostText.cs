using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Post
{
    public class PostText : IValueObject
    {
        public string text { get; }

        public PostText(string text)
        {
            if (IsTextValid(text))
            {
                this.text = text;
            }
            else if (IsTextValid(text))
                throw new BusinessRuleValidationException("Text invalid");

        }

        public static bool IsTextValid(string text)
        {
            return text.Length > 0;
        }

    }
}
