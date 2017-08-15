using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;

namespace Assets.Systems.Src.Pressure
{
    public class Pressurisation
    {
        public static void Resources(PressurisationState state)
        {
            // Calculate resources
            state.Resources = state.Inventory.Resources();
            state.Dirtied.Remove(Properties.Resources);
        }
        public static void MolesOfGas(PressurisationState state)
        {
            // Calculate moles of gas
            state.MolesOfGas = 0;
            foreach (ResourceStack gas in state.Resources)
            {
                state.MolesOfGas += gas.type.MolarMass * gas.volume;
            }
            state.Dirtied.Remove(Properties.MolesOfGas);
        }
        // TODO Pressuristion.PercentMoles will resolve when I remove percent moles in this manner and replace it with the properly implemented Atmospherics system.
        public static void PercentMoles(PressurisationState state)
        {
            // Calculate percent moles
            int i = 0;
            foreach (ResourceStack gas in state.Resources)
            {
                state.PercentMoles[i] = gas.type.MolarMass * gas.volume / state.MolesOfGas;
            }
            state.Dirtied.Remove(Properties.PercentMoles);
        }
        // TODO Pressurisation.Temperature will resolve when I remove temperature in this manner and replace it with the properly implemented Temperature system.
        public static void Temperature(PressurisationState state)
        {
            // Calculate temperature
            state.Dirtied.Remove(Properties.Temperature);
        }
        public static void Volume(PressurisationState state)
        {
            // Calculate volume
            state.Volume = state.Inventory.MaxVolume();
            state.Dirtied.Remove(Properties.Volume);
        }
        public static void Pressure(PressurisationState state)
        {
            // Calculate pressure
            state.Pressure = (state.MolesOfGas * Consts.Math.IdealGasConstant * state.Temperature) / state.Volume;
            state.Dirtied.Remove(Properties.Pressure);
        }
        // TODO Pressurisation.PressureDesired will resolve when I remove pressure desired in this manner and replace it with the properly implemented Atmospherics system.
        public static void PressureDesired(PressurisationState state)
        {
            // Calculate pressure desired
            state.Dirtied.Remove(Properties.PressureDesired);
        }
        public static void ResourcesDesired(PressurisationState state)
        {
            // Calculate resources desired
            Mole molesDesired = MolesOfGasDesired(state);
            ResourceStack[] resourcesDesired = new ResourceStack[state.Resources.Length];
            for (int i = 0; i < state.Resources.Length; i++)
            {
                resourcesDesired[i] = new ResourceStack() { type = state.Resources[i].type, volume = molesDesired * state.PercentMoles[i] / state.Resources[i].type.MolarMass};
            }
            state.ResourcesDesired = resourcesDesired;
            state.Dirtied.Remove(Properties.ResourcesDesired);
        }

        public static Mole MolesOfGasDesired(PressurisationState state)
        {
            return (state.PressureDesired * state.Volume) / (Consts.Math.IdealGasConstant * state.Temperature) - state.MolesOfGas;
        }
    }
}
