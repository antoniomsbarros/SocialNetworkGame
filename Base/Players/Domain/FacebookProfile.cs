using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Players
{
    // Later this could be changed if the Facebook API is going to be used
    public class FacebookProfile : IValueObject
    {
        public string FacebookProfileLink { get; }

        public FacebookProfile(string link)
        {
            this.FacebookProfileLink = link; // for now there's no validation for this
        }

    }
}
