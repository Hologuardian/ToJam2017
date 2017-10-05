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
        /// Dictionary of handlers registered with Pressurisation, via Guid of some object.
        /// </summary>
        private Dictionary<Guid, StateHandler> handlers = new Dictionary<Guid, StateHandler>();

        /// <summary>
        /// The sequence number of the current update.
        /// </summary>
        private int sequence = 0;
        /// <summary>
        /// Returns the current sequence number of the pressurisation system.
        /// </summary>
        public int Sequence
        {
            get { return sequence; }
        }

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
                // TODO this needs to reference the gas mass, not volume (I think I corrected this, will run it by Mark)
                molesOfGas += gas.type.MolarMass * (gas.volume * gas.type.Density);
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
        public static General.SI.Atmosphere Pressure(Mole molesOfGas, Kelvin temperature, Litre volume)
        {
            // Calculate pressure
           return ((molesOfGas * temperature) * Consts.Math.IdealGasConstant) / volume;
        }
        /// <summary>
        /// Calculates the total number of moles of gas desired, after accounting for the current amount, to reach the pressure, and temperature specified, inside the volume. Uses Ideal Gas Law
        /// </summary>
        /// <param name="molesOfGas">The total number of moles of gas present.</param>
        /// <param name="pressure">The pressure desired in the system.</param>
        /// <param name="temperature">The temperature desired in the system.</param>
        /// <param name="volume">The volume of the system.</param>
        /// <returns></returns>
        public static Mole MolesOfGasDesired(Mole molesOfGas, General.SI.Atmosphere pressure, Kelvin temperature, Litre volume)
        {
            // Calculate moles desired
            return ((Pascal)pressure * volume) / (Consts.Math.IdealGasConstant * temperature) - molesOfGas;
        }
        /// <summary>
        /// Calculates the quantity of resources necessary to bring this system to the desired pressure at the desired temperature.
        /// </summary>
        /// <param name="resources">The resources present in the system.</param>
        /// <param name="composition">The gas composition of the system.</param>
        /// <param name="molesOfGasDesired">The number of moles of gas desired in the system.</param>
        /// <returns></returns>
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

        public Pressurisation()
        {
            handlers = new Dictionary<Guid, StateHandler>();
        }

        public void Handle(Guid target)
        {
            if (!handlers.ContainsKey(target))
                handlers.Add(target, new StateHandler(target, new Dump(Dump), 10));
        }

        public void Update()
        {
            foreach(KeyValuePair<Guid, StateHandler> pair in handlers)
            {
                pair.Value.Update(Update(pair.Value));
            }

            sequence++;
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
            return new PressurisationState(Literals.States.Pressurisation, sequence, state.self, state.atmospherics, state.inventory, pressure, resourcesDesired, molesOfGas, molesOfGasDesired);
        }

        public IState State(Guid target)
        {
            StateHandler handler;
            handlers.TryGetValue(target, out handler);
            if (handler != null)
                return handler.State;
            else
                return null;
        }

        public void Dump(StateHandler handler)
        {
            // TODO Database - Dump Pressurisation State to the Database
        }
    }
}
