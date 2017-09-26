using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine;
using Assets.General.SI;
using Assets.Resources.Src;
using Assets.Systems.Atmosphere;

namespace Assets.Systems.Pressure
{
    public class Pressurisation : ISystem
    {
        /// <summary>
        /// Calculates how many moles of gas are present in an array of resources, which must all be gasses.
        /// </summary>
        /// <param name="resources">An array of gasses.</param>
        /// <returns>The number of moles of gas present.</returns>
        public static Mole MolesOfGas(ResourceStack[] resources)
        {
            // Calculate moles of gas
            Mole molesOfGas = 0;
            foreach (ResourceStack gas in resources)
            {
                // TODO this needs to reference the gas mass, not volume
                molesOfGas += gas.type.MolarMass * gas.volume;
            }
            return molesOfGas;
        }
        /// <summary>
        /// Calculates the atmospheric pressure of gasses in a volume based on temperature and moles of gas present. Uses Ideal Gas Law.
        /// </summary>
        /// <param name="molesOfGas">The total number of moles of gas present.</param>
        /// <param name="temperature">The temperature of the gasses in the volume.</param>
        /// <param name="volume">The volume the gasses are within.</param>
        /// <returns>The pressure of the gasses inside the volume at a given temperature.</returns>
        public static Pascal Pressure(Mole molesOfGas, Kelvin temperature, Metre3 volume)
        {
            // Calculate pressure
           return ((molesOfGas * temperature) * Consts.Math.IdealGasConstant) / volume;
        }
        /// <summary>
        /// Calculates the total number of moles of gas desired on top of the current amount.
        /// </summary>
        /// <param name="molesOfGas"></param>
        /// <param name="pressure"></param>
        /// <param name="temperature"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public static Mole MolesOfGasDesired(Mole molesOfGas, Pascal pressure, Kelvin temperature, Metre3 volume)
        {
            // Calculate moles desired
            return (pressure * volume) / (Consts.Math.IdealGasConstant * temperature) - molesOfGas;
        }

        public static ResourceStack[] ResourcesDesired(ResourceStack[] resources, ResourceComposition[] composition, Mole molesOfGasDesired)
        {
            // Calculate resources desired
            ResourceStack[] resourcesDesired = new ResourceStack[resources.Length];
            for (int i = 0; i < resources.Length; i++)
            {
                resourcesDesired[i] = new ResourceStack() { type = resources[i].type, volume = molesOfGasDesired * composition[i].percentage / resources[i].type.MolarMass * resources[i].type.Density };
            }
            return resourcesDesired;
        }

        public void Handle(Guid target)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            
        }

        public IState Update(StateHandler handler)
        {
            PressurisationState state = (PressurisationState)handler.State;
            AtmosphereState atmoState = state.atmospherics.State<AtmosphereState>();
            ResourceStack[] resources = state.inventory.Resources();
            ResourceComposition[] composition = atmoState.composition;
            Mole molesOfGas = MolesOfGas(resources);
            Pascal pressure = Pressure(molesOfGas, atmoState.temperature, state.inventory.MaxVolume());
            Mole molesOfGasDesired = MolesOfGasDesired(molesOfGas, pressure, atmoState.temperature, state.inventory.MaxVolume());
            ResourceStack[] resourcesDesired = ResourcesDesired(resources, composition, molesOfGasDesired);
            return new PressurisationState(state.name, state.update + 1, state.self, state.atmospherics, state.inventory, pressure, resourcesDesired, molesOfGas, molesOfGasDesired);
        }

        public IState State(Guid target)
        {
            throw new NotImplementedException();
        }

        public void Dump(StateHandler handler)
        {
            throw new NotImplementedException();
        }
    }
}
