using LEI_21s5_3dg_41.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class ConnectionStrenght : IValueObject
    {
        public int Strenght { get; }

        public ConnectionStrenght(int strenght)
        {
            this.Strenght = strenght; // There's a min and/or max?
        }

    }
}
