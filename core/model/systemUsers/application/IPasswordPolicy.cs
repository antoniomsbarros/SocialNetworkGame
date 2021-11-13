namespace SocialNetwork.core.model.systemUsers.application
{
    public interface IPasswordPolicy
    {
        bool IsSatisfiedBy(string password);
    }
}