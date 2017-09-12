using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;
using Assets.Systems.Src.Atmosphere;
using Assets.Systems.Src.Connection;

namespace Assets.Systems.Src.Pressure
{
    /// <summary>
    /// This class contains the complete state information of any one IPressurisation system, as a snapshot at that moment in time.
    /// </summary>
    public class PressurisationState : State
    {
        public Guid atmospherics;
        public IInventory inventory;
        public Guid self;

        public Pascal pressure = 0;
        public Pascal pressureDesired = 0;
        public Kelvin temperature = 0;
        public Metre3 volume = 0;
        public ResourceStack[] resources;
        public ResourceStack[] resourcesDesired;
        public Mole molesOfGas = 0;
        public Mole molesOfGasDesired = 0;
        public ResourceComposition[] composition;

        public PressurisationState(string name, int update, Guid self, Guid atmospherics, IInventory inventory) : base(name, update)
        {
            this.self = self;
            this.inventory = inventory;
            this.atmospherics = atmospherics;

            Pressurisation.Update(this);
        }
    }
}
