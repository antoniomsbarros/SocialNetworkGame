using System.Text.RegularExpressions;
using SocialNetwork.core.model.systemUsers.application;

namespace SocialNetwork.core.model.players.application
{
    public class PlayerPasswordPolicy : IPasswordPolicy
    {
        private const string PassRegex =
            @".*";

        public bool IsSatisfiedBy(string password)
        {
            return new Regex(PassRegex).IsMatch(password) && password.Length >= 8;
        }
    }
}