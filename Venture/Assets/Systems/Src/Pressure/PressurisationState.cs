using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine;
using Assets.General.SI;
using Assets.Resources.Src;
using Assets.Systems.Atmosphere;
using Assets.Systems.Connection;

namespace Assets.Systems.Pressure
{
    /// <summary>
    /// This struct contains the complete state information of any one IPressurisation system, as a snapshot at that moment in time.
    /// </summary>
    public struct PressurisationState : IState
    {
        public Guid atmospherics;
        public IInventory inventory;
        public Guid self;

        public string name;
        public int update;

        public Pascal pressure;
        public Pascal pressureDesired;
        public Kelvin temperature;
        public Metre3 volume;
        public ResourceStack[] resources;
        public ResourceStack[] resourcesDesired;
        public Mole molesOfGas;
        public Mole molesOfGasDesired;
        public ResourceComposition[] composition;

        public PressurisationState(string name, int update, Guid self, Guid atmospherics, IInventory inventory)
        {
            this.name = name;
            this.update = update;

            this.self = self;
            this.inventory = inventory;
            this.atmospherics = atmospherics;

            pressure = 0;
            pressureDesired = 0;
            temperature = 0;
            volume = 0;
            resources = null;
            resourcesDesired = null;
            molesOfGas = 0;
            molesOfGasDesired = 0;
            composition = null;

            Pressurisation.Update(this);
        }

        public object[] Parameters()
        {
            return new object[] { name, update, self, atmospherics, inventory, pressure, pressureDesired, temperature, volume, resources, resourcesDesired, molesOfGas, molesOfGasDesired, composition };
        }
    }
}
