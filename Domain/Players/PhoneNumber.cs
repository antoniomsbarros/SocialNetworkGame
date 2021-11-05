using LEI_21s5_3dg_41.Domain.Shared;
using System.Text.RegularExpressions;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class PhoneNumber : IValueObject
    {
        public string Number { get; }

        private static readonly string PHONE_NUMBER_REGEX_RULE = "[0-9]*";

        public PhoneNumber(string number)
        {
            if (IsValid(number))
                this.Number = number;
            else
                throw new BusinessRuleValidationException("Phone number invalid");
        }

        public static bool IsValid(string number)
        {
            Regex regex = new(PHONE_NUMBER_REGEX_RULE);
            return regex.IsMatch(number);
        }

    }
}
