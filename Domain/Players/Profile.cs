using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Tag;

using System;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class Profile :Entity<ProfileId>
    {
        public string name { get;  private set; }

        public EmotionalStatus emotionalStatus { get;  private set; }

        public List<TagId> tags  { get;  private set; }

        public Profile(string name, List<TagId> tags)
        {
            this.Id = new ProfileId(Guid.NewGuid());
            this.name = name;
            this.tags=tags;
        }
        public void ChangeName(string name){
            this.name=name;
        }


    }
}