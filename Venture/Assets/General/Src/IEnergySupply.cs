using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.General.Src.SI;

namespace Assets.General.Src
{
    public interface IEnergySupply
    {
        /// <summary>
        /// Returns a reference to this volatile object
        /// </summary>
        /// <returns>This volatile object</returns>
        VolatileObject Self();
        /// <summary>
        /// Energy returns the net energy of this IEnergySupply.
        /// </summary>
        /// <returns>The current energy in this IEnergySupply in WattHours.</returns>
        WattHour Energy();
        /// <summary>
        /// Energy Supply returns the energy being supplied from connected modules.
        /// </summary>
        /// <returns>The current energy being supplied to this IEnergySupply in WattHours.</returns>
        WattHour EnergySupply();
        /// <summary>
        /// Energy Production returns the total energy being produced or consumed by this IEnergySupply.
        /// </summary>
        /// <returns>The current energy production in WattHours.</returns>
        WattHour EnergyProduction();
        /// <summary>
        /// Sets the energy production to the passed watthour value.
        /// </summary>
        /// <param name="WH">The value to set energy production to.</param>
        void EnergyProduction(WattHour WH);
        /// <summary>
        /// Energy Line Loss returns the total energy lost in transit through this IEnergySupply.
        /// </summary>
        /// <returns>The energy lost to line loss in WattHours.</returns>
        WattHour EnergyLineLoss();
        /// <summary>
        /// Line Loss is the percentage of power lost in transit.
        /// </summary>
        /// <returns>The percentage of power lost in transit.</returns>
        float LineLoss();
        /// <summary>
        /// Sets line loss to the passed float.
        /// </summary>
        /// <param name="lineLossTo">The value to set line loss to.</param>
        void LineLoss(float lineLossTo);
    }
}
