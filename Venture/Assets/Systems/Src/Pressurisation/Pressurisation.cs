using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;

namespace Assets.Systems.Src.Pressurisation
{
    public class Pressurisation
    {
        public static void Update(PressurisationState state)
        {
            // So for each kind of update I have written dependants, which are those things this update requires updated first if dirty.
            // As well they each have written dependancies, which are those things that must update after this thing.

            bool pressureHasUpdated = false;

            // Resources ---------------------------------------------------------------------------------
            // Dependants
            // MolesOfGas
            if (state.Dirtied.Has(Properties.Resources))
            {
                // Whenever resources changes that changes the number of moles of gas present.
                MolesOfGas(state);
                state.Dirtied.Remove(Properties.Resources);
            }

            // Moles of Gas ------------------------------------------------------------------------------
            // Dependants
            // Resources
            // Dependancies
            // Pressure
            if (state.Dirtied.Has(Properties.MolesOfGas))
            {
                // The number of moles of gas has changed, which means pressure needs to be recalculated.
                Pressure(state);
                pressureHasUpdated = true;
                state.Dirtied.Remove(Properties.MolesOfGas);
            }

            // Temperature -------------------------------------------------------------------------------
            // Dependancies
            // Pressure
            if (!pressureHasUpdated && state.Dirtied.Has(Properties.Temperature))
            {
                // The temperature of the pressurisation volume has changed which requires a recalculation of pressure
                Pressure(state);
                pressureHasUpdated = true;
                state.Dirtied.Remove(Properties.Temperature);
            }

            // Volume ------------------------------------------------------------------------------------
            // Dependancies
            // Pressure
            if (!pressureHasUpdated && state.Dirtied.Has(Properties.Volume))
            {
                // The volume of this pressurisation system has changed which requires a recalculation of pressure
                Pressure(state);
                pressureHasUpdated = true;
                state.Dirtied.Remove(Properties.Volume);
            }

            // Pressure ----------------------------------------------------------------------------------
            // Dependants
            // MolesOfGas, Volume, Temperature
            // Dependancies
            // ResourcesDesired
            if (state.Dirtied.Has(Properties.Pressure))
            {
                // If Pressure has been dirtied then that means something has recalculated pressure.
                // This is the case whenever other properties have been altered, like the current temperature in this pressurisation system.
                // When pressure has been dirtied a recalculation of desired resources should be done.

                // TODO Desired Resources Volume Calculation
            }

            // Pressure Desired --------------------------------------------------------------------------
            // Dependancies
            // ResourcesDesired
            if (state.Dirtied.Has(Properties.PressureDesired))
            {

            }

            // Resources Desired -------------------------------------------------------------------------
            // Dependants
            // PressureDesired
            if (state.Dirtied.Has(Properties.ResourcesDesired))
            {
                // Can't really think of anything I would need to update based on if this is dirty or not.
            }

            state.Dirty = false;
            state.Dirtied = Properties.None;
        }

        public static void Pressure(PressurisationState state)
        {
            state.Pressure = (state.MolesOfGas * Consts.Math.IdealGasConstant * state.Temperature) / state.Volume;
        }

        public static void MolesOfGas(PressurisationState state)
        {
            state.MolesOfGas = 0;
            foreach (ResourceStack gas in state.Resources)
            {
                state.MolesOfGas += gas.type.MolarMass * gas.volume;
            }
        }

        public static void ResourcesDesired(PressurisationState state)
        {
            Mole molesDesired = MolesOfGasDesired(state);
            molesDesired -= state.MolesOfGas;
            ResourceStack[] resourcesDesired = new ResourceStack[state.Resources.Length];
            for(int i = 0; i < state.Resources.Length; i++)
            {
                resourcesDesired[i] = new ResourceStack() { type = state.Resources[i].type, volume = molesDesired * state.PercentMoles[i] };
            }
        }

        public static Mole MolesOfGasDesired(PressurisationState state)
        {
            return (state.PressureDesired * state.Volume) / (Consts.Math.IdealGasConstant * state.Temperature);
        }
    }
}
