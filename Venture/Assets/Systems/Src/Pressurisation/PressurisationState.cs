using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;
using Assets.Systems.Src.Connections;

namespace Assets.Systems.Src.Pressurisation
{
    [Flags]
    public enum Properties { None = 0, Pressure = 1, PressureDesired = 2, Temperature = 4, Resources = 8, ResourcesDesired = 16, Volume = 32, MolesOfGas = 64, PercentMoles = 128,  All = 255 }

    /// <summary>
    /// This class contains the complete state information of any one IPressurisation system.
    /// Use discretion when accessing and modifying this, as it could lead to race conditions without proper locking procedure.
    /// </summary>
    public class PressurisationState : State
    {
        public Properties Dirtied = Properties.None;

        private IPressurisation pressurisation;
        public IPressurisation Pressurisation
        {
            get
            {
                return pressurisation;
            }
        }
        private IConnections[] connections;
        public IConnections[] Connections
        {
            get
            {
                return connections;
            }
        }
        private Pascal pressure = 0;
        public Pascal Pressure
        {
            get
            {
                return pressure;
            }
            set
            {
                pressure = value;
                Dirty = true;
                Dirtied.Add(Properties.Pressure);
            }
        }
        private Pascal pressureDesired = 0;
        public Pascal PressureDesired
        {
            get
            {
                return pressureDesired;
            }
            set
            {
                pressureDesired = value;
                Dirty = true;
                Dirtied.Add(Properties.PressureDesired);
            }
        }
        private Kelvin temperature = 0;
        public Kelvin Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                Dirty = true;
                Dirtied.Add(Properties.Temperature);
            }
        }
        private IInventory inventory;
        public IInventory Inventory
        {
            get
            {
                return inventory;
            }
        }
        private ResourceStack[] resources;
        public ResourceStack[] Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
                Dirty = true;
                Dirtied.Add(Properties.Resources);
            }
        }
        private ResourceStack[] resourcesDesired;
        public ResourceStack[] ResourcesDesired
        {
            get
            {
                return resourcesDesired;
            }
            set
            {
                resourcesDesired = value;
                Dirty = true;
                Dirtied.Add(Properties.ResourcesDesired);
            }
        }
        private Metre3 volume = 0;
        public Metre3 Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                Dirty = true;
                Dirtied.Add(Properties.Volume);
            }
        }
        private Mole molesOfGas = 0;
        public Mole MolesOfGas
        {
            get
            {
                return molesOfGas;
            }
            set
            {
                molesOfGas = value;
                Dirty = true;
                Dirtied.Add(Properties.MolesOfGas);
            }
        }
        private float[] percentMoles;
        public float[] PercentMoles
        {
            get
            {
                return percentMoles;
            }
            set
            {
                percentMoles = value;
                Dirty = true;
                Dirtied.Add(Properties.PercentMoles);
            }
        }

        public PressurisationState(string name, VolatileObject self, Pascal pressureDesired, Kelvin temperature, IInventory inventory) : base(name)
        {
            pressurisation = self as IPressurisation;
            connections = (self as IConnections).Connections();
            this.pressureDesired = pressureDesired;
            this.temperature = temperature;
            this.inventory = inventory;
            Dirtied.Add(Properties.All);
        }
    }
}
