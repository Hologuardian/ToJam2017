using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Src.Electricity
{
    public class ElectricalGrid
    {
        public static void Energy(EnergyState state)
        {
            // Calculate energy
            state.Energy = state.EnergyProduction - state.EnergyConsumption;
            state.Dirtied.Remove(Properties.Energy);
        }
        public static void EnergyProduction(EnergyState state)
        {
            // Calculate energy production
            // Save this is set by user operation, not by calculation, so for now this has no need
            state.Dirtied.Remove(Properties.EnergyProduction);
        }
        public static void EnergyConsumption(EnergyState state)
        {
            // Calculate energy consumption
            // Save this is set by user operation, not by calculation, so for now this has no need
            state.Dirtied.Remove(Properties.EnergyConsumption);
        }
        public static void EnergyLoss(EnergyState state)
        {
            // Calculate energy loss
            state.EnergyLoss = state.Energy * state.LineLoss;
            state.Dirtied.Remove(Properties.EnergyLoss);
        }
        public static void LineLoss(EnergyState state)
        {
            // Calculate line loss
            // Save this again is set by user operation, not by calculation, so for now this has no need
            state.Dirtied.Remove(Properties.LineLoss);
        }
    }
}
