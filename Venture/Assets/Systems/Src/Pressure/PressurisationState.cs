using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;
using Assets.Systems.Src.Connection;

namespace Assets.Systems.Src.Pressure
{
    [Flags]
    public enum Properties { None = 0, Pressure = 1, PressureDesired = 2, Temperature = 4, Resources = 8, ResourcesDesired = 16, Volume = 32, MolesOfGas = 64, PercentMoles = 128,  All = 255 }

    /// <summary>
    /// This class contains the complete state information of any one IPressurisation system.
    /// <para>Use discretion when accessing and modifying this, as it could lead to race conditions without proper locking procedure.</para>
    /// </summary>
    public class PressurisationState : State
    {
        /// <summary>
        /// Dependancies defines which state fields require others values be most up to date.
        /// </summary>
        public static Dictionary<Properties, Properties> Dependancies = new Dictionary<Properties, Properties>
        {
            { Properties.Temperature, Properties.None },
            { Properties.Volume, Properties.None },
            { Properties.PressureDesired, Properties.None },
            { Properties.Resources, Properties.None },
            { Properties.MolesOfGas, Properties.Resources },
            { Properties.PercentMoles, Properties.MolesOfGas | Properties.Resources },
            { Properties.Pressure, Properties.MolesOfGas | Properties.Temperature | Properties.Volume },
            { Properties.ResourcesDesired, Properties.Pressure | Properties.PressureDesired | Properties.PercentMoles | Properties.Resources }
        };

        public Properties Dirtied = Properties.None;

        //private IPressurisation pressurisation;
        ///// <summary>
        ///// Returns a reference to the pressurisation system this state is pertinant to
        ///// </summary>
        //public IPressurisation Pressurisation
        //{
        //    get
        //    {
        //        return pressurisation;
        //    }
        //}
        //private IConnections[] connections;
        ///// <summary>
        ///// Returns a reference to the array of connections this pressurisation system is connected to
        ///// </summary>
        //public IConnections[] Connections
        //{
        //    get
        //    {
        //        return connections;
        //    }
        //}
        private Pascal pressure = 0;
        /// <summary>
        /// Pressure is the pressure of this state of a pressurisation system's volume as defined by the pressurisation system's inventory.
        /// <para>Dependancies must be updated before this value is gotten.</para>
        /// <para>Dependants must be updated before their value is gotten, after this value has been changed.</para>
        /// <para>Dependancies: MolesOfGas, Temperature, Volume.</para>
        /// <para>Dependants: ResourcesDesired.</para>
        /// </summary>
        public Pascal Pressure
        {
            get
            {
                if (Dirtied.Has(Properties.Pressure))
                    Pressurisation.Pressure(this);

                return pressure;
            }
            set
            {
                pressure = value;
                Dirtied.Add(Properties.Pressure);
            }
        }
        private Pascal pressureDesired = 0;
        /// <summary>
        /// Pressure desired is the pressure this state is desiring to reach within the pressurisation system's volume as defined by the pressurisation system's inventory.
        /// <para>Dependancies must be updated before this value is gotten.</para>
        /// <para>Dependants must be updated before their value is gotten, after this value has been changed.</para>
        /// <para>Dependants: ResourcesDesired.</para>
        /// </summary>
        public Pascal PressureDesired
        {
            get
            {
                if (Dirtied.Has(Properties.PressureDesired))
                    Pressurisation.PressureDesired(this);

                return pressureDesired;
            }
            set
            {
                pressureDesired = value;
                Dirtied.Add(Properties.PressureDesired);
            }
        }
        private Kelvin temperature = 0;
        /// <summary>
        /// Temperature is the temperature of this state of a pressurisation system's volume as defined by the pressurisation system's inventory.
        /// <para>Dependancies must be updated before this value is gotten.</para>
        /// <para>Dependants must be updated before their value is gotten, after this value has been changed.</para>
        /// <para>Dependants: Pressure.</para>
        /// </summary>
        public Kelvin Temperature
        {
            get
            {
                if (Dirtied.Has(Properties.Temperature))
                    Pressurisation.Temperature(this);

                return temperature;
            }
            set
            {
                temperature = value;
                Dirtied.Add(Properties.Temperature);
            }
        }
        private IInventory inventory;
        /// <summary>
        /// Returns a reference to the inventory of the pressurisation system.
        /// </summary>
        public IInventory Inventory
        {
            get
            {
                return inventory;
            }
        }
        private ResourceStack[] resources;
        /// <summary>
        /// Resources is the stack of resources this state of a pressurisation system's inventory 
        /// <para>Best Practices.</para>
        /// Often you will want to get a reference to this simply to see what to give it. Whenever you change anything about that reference, this doesn't know it has become dirty.
        /// Please remember to tell this it has been dirtied.
        /// <para>state.Dirtied.Add(Properties.Resources)</para>
        /// As well this has a ratio dependant, which only needs to be recalculated in the specific case you change the percentage breakdown of resource volumes.
        /// <para>Dependancies must be updated before this value is gotten.</para>
        /// <para>Dependants must be updated before their value is gotten, after this value has been changed.</para>
        /// <para>Dependants: MolesOfGas, PercentMoles, ResourcesDesired</para>
        /// </summary>
        public ResourceStack[] Resources
        {
            get
            {
                if (Dirtied.Has(Properties.Resources))
                    Pressurisation.Resources(this);

                return resources;
            }
            set
            {
                resources = value;
                Dirtied.Add(Properties.Resources);
            }
        }
        private ResourceStack[] resourcesDesired;
        /// <summary>
        /// 
        /// </summary>
        public ResourceStack[] ResourcesDesired
        {
            get
            {
                if (Dirtied.Has(Properties.ResourcesDesired))
                    Pressurisation.ResourcesDesired(this);

                return resourcesDesired;
            }
            set
            {
                resourcesDesired = value;
                Dirtied.Add(Properties.ResourcesDesired);
            }
        }
        private Metre3 volume = 0;
        /// <summary>
        /// 
        /// </summary>
        public Metre3 Volume
        {
            get
            {
                if (Dirtied.Has(Properties.Volume))
                    Pressurisation.Volume(this);

                return volume;
            }
            set
            {
                volume = value;
                Dirtied.Add(Properties.Volume);
            }
        }
        private Mole molesOfGas = 0;
        /// <summary>
        /// 
        /// </summary>
        public Mole MolesOfGas
        {
            get
            {
                if (Dirtied.Has(Properties.MolesOfGas))
                    Pressurisation.MolesOfGas(this);

                return molesOfGas;
            }
            set
            {
                molesOfGas = value;
                Dirtied.Add(Properties.MolesOfGas);
            }
        }
        private float[] percentMoles;
        /// <summary>
        /// 
        /// </summary>
        public float[] PercentMoles
        {
            get
            {
                if (Dirtied.Has(Properties.PercentMoles))
                    Pressurisation.PercentMoles(this);

                return percentMoles;
            }
            set
            {
                percentMoles = value;
                Dirtied.Add(Properties.PercentMoles);
            }
        }

        public PressurisationState(string name, VolatileObject self, Pascal pressureDesired, Kelvin temperature, IInventory inventory) : base(name)
        {
            //pressurisation = self as IPressurisation;
            //connections = (self as IConnections).Connections();
            this.pressureDesired = pressureDesired;
            this.temperature = temperature;
            this.inventory = inventory;
            Dirtied.Add(Properties.All);
        }
    }
}
