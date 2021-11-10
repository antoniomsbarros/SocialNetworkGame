using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.core.shared
{
    interface IDomainFactory<T>
    {
        T BuildOrIgnore();

        T Build();
    }
}
