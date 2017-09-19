using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine;

namespace Assets.Station
{
    public abstract class UpdateDecorator 
    {
        protected VolatileObject target;

        public UpdateDecorator(VolatileObject target)
        {
            this.target = target;
        }

        public abstract void Update();
    }
}
