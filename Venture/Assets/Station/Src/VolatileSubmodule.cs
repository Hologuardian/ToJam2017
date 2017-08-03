using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.Station.Src
{
    public abstract class VolatileSubmodule : VolatileObject
    {
        public abstract void Update();
    }
}
