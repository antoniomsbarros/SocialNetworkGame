using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.core.shared
{
    interface IDomainBuilder<T>
    {
        T BuildOrIgnore();

        T Build();
    }
}
