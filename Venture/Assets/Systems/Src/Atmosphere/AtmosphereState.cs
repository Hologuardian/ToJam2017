using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.SI;
using Assets.Resources.Src;

namespace Assets.Systems.Atmosphere
{
    public struct ResourceComposition
    {
        public Resource type;
        public float percentage;
    }

    public struct AtmosphereState : IState
    {
        public Guid self;

        public string name;
        public int update;

        public Pascal pressure;
        public Kelvin temperature;
        public ResourceComposition[] composition;

        public AtmosphereState(string name, int update, Guid self, ResourceComposition[] composition, Pascal pressure, Kelvin temperature)
        {
            this.name = name;
            this.update = update;
            this.self = self;
            this.pressure = pressure;
            this.temperature = temperature;
            this.composition = composition;
        }

        public object[] Parameters()
        {
            return new object[] { name, update, self, pressure, temperature, composition };
        }
    }
}
