using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.Src.SI;

namespace Assets.Resources.Src
{
    public struct ResourceStack
    {
        public ResourceStack(Resource type, Metre3 volume)
        {
            this.type = type;
            this.volume = volume;
        }
        public Resource type;
        public Metre3 volume;
    }
}