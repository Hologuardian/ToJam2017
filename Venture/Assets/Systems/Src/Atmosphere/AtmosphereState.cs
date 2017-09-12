using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.Src.SI;
using Assets.Resources.Src;

namespace Assets.Systems.Src.Atmosphere
{
    public struct ResourceComposition
    {
        public Resource type;
        public float percentage;
    }

    public class AtmosphereState : State
    {
        public Guid self;

        public Pascal pressure = 0;
        public Kelvin temperature = 0;
        public ResourceComposition[] composition;

        public AtmosphereState(string name, int update, Guid self, ResourceComposition[] composition, Pascal pressure, Kelvin temperature) : base(name, update)
        {
            this.self = self;
            this.pressure = pressure;
            this.temperature = temperature;
            this.composition = composition;
        }
    }
}
