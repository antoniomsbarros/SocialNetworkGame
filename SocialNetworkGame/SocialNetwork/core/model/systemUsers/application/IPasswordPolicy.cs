namespace SocialNetwork.core.model.systemUsers.application
{
    public interface IPasswordPolicy
    {
        bool IsValidPassword(string password);

        PasswordStrength GetPasswordStrength(string password);

        bool HasMinimumLength(string password, int minLength);

        bool HasMinimumUniqueChars(string password, int minUniqueChars);

        bool HasDigit(string password);

        bool HasSpecialChar(string password);

        bool HasUpperCaseLetter(string password);

        bool HasLowerCaseLetter(string password);
    }
}