namespace SocialNetwork.core.model.shared
{
    public interface IDTOable<T>
    {
        public T ToDto();
    }
}