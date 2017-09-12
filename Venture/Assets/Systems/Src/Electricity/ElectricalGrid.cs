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
            state.energy = state.energyProduction - state.energyConsumption;
        }
        public static void EnergyProduction(EnergyState state)
        {
            // Calculate energy production
            // Save this is set by user operation, not by calculation, so for now this has no need
        }
        public static void EnergyConsumption(EnergyState state)
        {
            // Calculate energy consumption
            // Save this is set by user operation, not by calculation, so for now this has no need
        }
        public static void EnergyLoss(EnergyState state)
        {
            // Calculate energy loss
            state.energyLoss = state.energy * state.lineLoss;
        }
        public static void LineLoss(EnergyState state)
        {
            // Calculate line loss
            // Save this again is set by user operation, not by calculation, so for now this has no need
        }
    }
}
