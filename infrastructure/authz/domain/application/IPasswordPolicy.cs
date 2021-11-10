namespace SocialNetwork.infrastructure.authz.domain.application
{
    public interface IPasswordPolicy
    {
        bool IsSatisfiedBy(string password);
    }
}