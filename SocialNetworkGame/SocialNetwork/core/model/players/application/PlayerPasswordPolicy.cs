using System;
using System.Linq;
using SocialNetwork.core.model.systemUsers.application;
using Microsoft.Extensions.Configuration;

namespace SocialNetwork.core.model.players.application
{
    public class PlayerPasswordPolicy : IPasswordPolicy
    {
        private readonly IConfiguration _config;

        public PlayerPasswordPolicy(IConfiguration configuration)
        {
            _config = configuration;
        }

        public bool IsValidPassword(string password)
        {
            return IsValidPassword(password,
                Int32.Parse(_config["PasswordPolicy:ForPlayer:RequiredLength"]),
                Int32.Parse(_config["PasswordPolicy:ForPlayer:RequiredUniqueChars"]),
                Boolean.Parse(_config["PasswordPolicy:ForPlayer:RequireNonAlphanumeric"]),
                Boolean.Parse(_config["PasswordPolicy:ForPlayer:RequireLowercase"]),
                Boolean.Parse(_config["PasswordPolicy:ForPlayer:RequireUppercase"]),
                Boolean.Parse(_config["PasswordPolicy:ForPlayer:RequireDigit"]));
        }

        private bool IsValidPassword(
            string password,
            int requiredLength,
            int requiredUniqueChars,
            bool requireNonAlphanumeric,
            bool requireLowercase,
            bool requireUppercase,
            bool requireDigit)
        {
            if (!HasMinimumLength(password, requiredLength)) return false;
            if (!HasMinimumUniqueChars(password, requiredUniqueChars)) return false;
            if (requireNonAlphanumeric && !HasSpecialChar(password)) return false;
            if (requireLowercase && !HasLowerCaseLetter(password)) return false;
            if (requireUppercase && !HasUpperCaseLetter(password)) return false;
            if (requireDigit && !HasDigit(password)) return false;
            return true;
        }

        public PasswordStrength GetPasswordStrength(string password)
        {
            int score = 0;
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password.Trim())) return PasswordStrength.Blank;
            if (HasMinimumLength(password, 5)) score++;
            if (HasMinimumLength(password, 8)) score++;
            if (HasUpperCaseLetter(password) && HasLowerCaseLetter(password)) score++;
            if (HasDigit(password)) score++;
            if (HasSpecialChar(password)) score++;
            return (PasswordStrength) score;
        }

        public bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }

        public bool HasMinimumUniqueChars(string password, int minUniqueChars)
        {
            return password.Distinct().Count() >= minUniqueChars;
        }

        public bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        public bool HasSpecialChar(string password)
        {
            return password.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }

        public bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        public bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }
    }
}