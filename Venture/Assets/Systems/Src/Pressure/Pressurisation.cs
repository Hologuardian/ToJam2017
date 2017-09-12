using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;
using Assets.Systems.Src.Atmosphere;

namespace Assets.Systems.Src.Pressure
{
    public class Pressurisation
    {
        /// <summary>
        /// Updates the PressurisationState resources, to reflect the resources in the inventory bound to the state.
        /// </summary>
        /// <param name="state">The state to update resources on</param>
        public static void Resources(PressurisationState state)
        {
            // Calculate resources
            state.resources = state.inventory.Resources();
        }
        /// <summary>
        /// Updates the current total moles of gas in this pressurisation system.
        /// </summary>
        /// <param name="state">The state to determine moles of gas on</param>
        public static void MolesOfGas(PressurisationState state)
        {
            // Calculate moles of gas
            state.molesOfGas = 0;
            foreach (ResourceStack gas in state.resources)
            {
                state.molesOfGas += gas.type.MolarMass * gas.volume;
            }
        }
        /// <summary>
        /// Updates the percentage moles of this state, via the atmospherics composition.
        /// </summary>
        /// <param name="state">The state to determine composition on</param>
        public static void PercentMoles(PressurisationState state)
        {
            // Calculate percent moles
            state.composition = state.atmospherics.State().composition;
        }
        /// <summary>
        /// Updates the temperature of this state, via the atmospherics temperature.
        /// </summary>
        /// <param name="state">The state to determine temperature on</param>
        public static void Temperature(PressurisationState state)
        {
            // Calculate temperature
            state.temperature = state.atmospherics.State().temperature;
        }
        /// <summary>
        /// Updates the pressure of this state using the Ideal Gas Law, this requires up to date volume, temperature, and moles of gas information, in the state.
        /// </summary>
        /// <param name="state">The state to determine the pressure of</param>
        public static void Pressure(PressurisationState state)
        {
            // Calculate pressure
            state.pressure = (state.molesOfGas * Consts.Math.IdealGasConstant * state.temperature) / state.volume;
        }
        /// <summary>
        /// Updates the resources desired by this pressurisation subsystem in order to achieve the pressure desired by the atmospherics subsystem of this module.
        /// </summary>
        /// <param name="state">The state to determine the required resources on</param>
        public static void ResourcesDesired(PressurisationState state)
        {
            // Calculate resources desired
            state.resourcesDesired = new ResourceStack[state.resources.Length];
            for (int i = 0; i < state.resources.Length; i++)
            {
                state.resourcesDesired[i] = new ResourceStack() { type = state.resources[i].type, volume = state.molesOfGasDesired * state.composition[i].percentage / state.resources[i].type.MolarMass};
            }
        }
        /// <summary>
        /// Updates the moles of gas necessary to pressurise this subsystem to the desired pressure, this requires up to date information on volume, temperature, moles of gas, and pressure desired.
        /// </summary>
        /// <param name="state">The state to determine the moles of gas desired on.</param>
        public static void MolesOfGasDesired(PressurisationState state)
        {
            // Calculate moles desired
            state.molesOfGasDesired = (state.pressureDesired * state.volume) / (Consts.Math.IdealGasConstant * state.temperature) - state.molesOfGas;
        }
        /// <summary>
        /// Updates a pressurisation subsystem's state, and returns it.
        /// </summary>
        /// <param name="subsystem">The pressurisation subsystem requiring update.</param>
        /// <param name="update">The update sequence number (no logic is done at this stage to determine if the subsystem should update or not).</param>
        /// <returns>The state of the pressurisation subsystem after updating.</returns>
        public static PressurisationState Update(Guid subsystem, int update)
        {
            PressurisationState lastState = subsystem.State();
            PressurisationState nextState = new PressurisationState(lastState.name, update, subsystem, lastState.atmospherics, lastState.inventory);
            Update(nextState);
            return nextState;
        }
        /// <summary>
        /// Binds the required pressurisation, inventory, atmospherics, and root state to the pressurisation subsystem, ensuring that all future states have all references pre-established for the properties they need.
        /// </summary>
        /// <param name="self">The pressurisation subsystem in question.</param>
        /// <param name="inventory">The inventory to bind to the subsystem (this is the inventory that represents the open space within the module).</param>
        /// <param name="atmospherics">The atmospherics subsystem attached to this module.</param>
        /// <param name="rootState">The state this pressurisation subsystem will use to store its current state.</param>
        public static void Bind(Guid self, IInventory inventory, Guid atmospherics, PressurisationState rootState)
        {
            rootState.self = self;
            rootState.inventory = inventory;
            rootState.atmospherics = atmospherics;
        }
        /// <summary>
        /// Updates all the properties of a pressurisation state, ensuring they each are true to the state based on those properties they derive from.
        /// <para>Pressure as an example requires up to date volume, moles of gas, and temperature values, and will therefor update after those values have been determined.</para>
        /// </summary>
        /// <param name="u">The state to update.</param>
        public static void Update(PressurisationState u)
        {
            // Start with the very root most properties, and work through the rest
            // Everything starts with some root dependancies, and external references
            // These would be temperature, pressureDesired, volume, and resources

            // Get the current state of the atmospherics subsystem, which defines the values desired of the atmosphere.
            AtmosphereState atmosphere = u.atmospherics.State();
            // Then store those values;
            u.temperature = atmosphere.temperature;
            u.pressureDesired = atmosphere.pressure;
            // Query resources
            u.resources = u.inventory.Resources();
            // Update volume
            u.volume = u.inventory.MaxVolume();
            // Calculate moles of gas
            MolesOfGas(u);
            // Calculate percent moles
            PercentMoles(u);
            // Calculate pressure
            Pressure(u);
            // Calculate moles desired
            MolesOfGasDesired(u);
            // Calculate resources desired
            ResourcesDesired(u);
            // Done
        }
    }
}
