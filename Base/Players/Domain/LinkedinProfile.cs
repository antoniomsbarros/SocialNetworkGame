using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Players
{
    // Read the comments from FacebookProfile
    public class LinkedinProfile : IValueObject
    {
        public string LinkedinProfileLink { get; }

        public LinkedinProfile(string link)
        {
            this.LinkedinProfileLink = link;
        }
    }
}
