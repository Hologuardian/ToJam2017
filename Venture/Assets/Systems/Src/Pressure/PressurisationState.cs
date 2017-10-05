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
        public readonly Guid atmospherics;
        public readonly IInventory inventory;
        public readonly Guid self;

        public readonly string name;
        public readonly int update;

        public readonly Pascal pressure;
        public readonly ResourceStack[] resourcesDesired;
        public readonly Mole molesOfGas;
        public readonly Mole molesOfGasDesired;

        public PressurisationState(string name, int update, Guid self, Guid atmospherics, IInventory inventory)
        {
            this.name = name;
            this.update = update;
            this.self = self;
            this.inventory = inventory;
            this.atmospherics = atmospherics;
            pressure = 0;
            resourcesDesired = null;
            molesOfGas = 0;
            molesOfGasDesired = 0;
        }

        public PressurisationState(string name, int update, Guid self, Guid atmospherics, IInventory inventory, Pascal pressure, ResourceStack[] resourcesDesired, Mole molesOfGas, Mole molesOfGasDesired)
        {
            this.name = name;
            this.update = update;
            this.self = self;
            this.atmospherics = atmospherics;
            this.inventory = inventory;
            this.pressure = pressure;
            this.resourcesDesired = resourcesDesired;
            this.molesOfGas = molesOfGas;
            this.molesOfGasDesired = molesOfGasDesired;
        }

        public PressurisationState(object[] parameters)
        {
            name = (string)parameters[1];
            update = (int)parameters[2];
            self = (Guid)parameters[3];
            atmospherics = (Guid)parameters[4];
            inventory = (IInventory)parameters[5];
            pressure = (Pascal)parameters[6];
            resourcesDesired = (ResourceStack[])parameters[7];
            molesOfGas = (Mole)parameters[8];
            molesOfGasDesired = (Mole)parameters[9];
        }

        public object[] Parameters()
        {
            return new object[] { Literals.States.Pressurisation, name, update, self, atmospherics, inventory, pressure, resourcesDesired, molesOfGas, molesOfGasDesired };
        }

        /// <summary>
        /// Given that Guid has been extended to allow the returning of states by querying a Guid for a specified state type, it is necessary that in the event of a GenericState return, it can implicitly cast to a PressurisationState
        /// </summary>
        /// <param name="state">The GenericState to turn into an empty PressurisationState</param>
        public static implicit operator PressurisationState(GenericState state)
        {
            if (state.parameters.Length == 0)
                return new PressurisationState("GenericState to PressurisationState", 0, Guid.Empty, Guid.Empty, null);
            else if ((string)state.parameters[0] == Literals.States.Pressurisation)
                return new PressurisationState(state.parameters);
            else
                return new PressurisationState();
        }
    }
}
