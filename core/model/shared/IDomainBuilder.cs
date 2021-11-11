namespace SocialNetwork.core.model.shared
{
    interface IDomainBuilder<out T>
    {
        T BuildOrIgnore();

        T Build();
    }
}