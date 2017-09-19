using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine;

namespace Assets.Station
{
    public abstract class VolatileSubmodule : VolatileObject
    {
        public abstract void Update();
    }
}
