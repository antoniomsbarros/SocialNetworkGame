using LEI_21s5_3dg_41.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEI_21s5_3dg_41.Domain.Tag
{
    public class TagName : IValueObject
    {

        public string Name { get; }

        public TagName(string tagName)
        {
            if (IsValid(tagName))
                this.Name = tagName;
            else
                throw new BusinessRuleValidationException("Tag name invalid");
        }

        public static bool IsValid(string tagName)
        {
            return tagName.Length > 0;
        }

    }
}
