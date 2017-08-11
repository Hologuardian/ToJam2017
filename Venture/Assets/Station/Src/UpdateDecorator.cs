using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.Station.Src
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
