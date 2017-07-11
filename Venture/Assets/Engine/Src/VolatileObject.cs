using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine.Src
{
    public class VolatileObject
    {
        public bool IsDead { get; private set; }

        public void Kill()
        {
            IsDead = true;
        }
    }
}
