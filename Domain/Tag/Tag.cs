using System;
using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Tag
{
    public class Tag  : Entity<TagId>, IAggregateRoot
    {
        public string TagName { get;  private set; }

    public Tag (string TagName){
        this.Id=new TagId(Guid.NewGuid());
        this.TagName=TagName;
    }

    public void ChangeTag(string newTag){
        this.TagName=newTag;
    }

    }
}