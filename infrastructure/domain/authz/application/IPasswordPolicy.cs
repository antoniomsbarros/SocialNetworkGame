namespace SocialNetwork.infrastructure.application.authz
{
    public interface IPasswordPolicy
    {
        bool IsSatisfiedBy(string password);
    }
}
