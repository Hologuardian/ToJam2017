using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;

namespace Assets.General.Src
{
    /// <summary>
    /// IPressurisable defines the standards for all pressurisable objects, such that they must have some inventory to store the gases in.
    /// As well they must implement a selection of useful 'getter' 'setter' type methods.
    /// </summary>
    public interface IPressurisable
    {
        /// <summary>
        /// Returns a reference to this volatile object
        /// </summary>
        /// <returns>This volatile object</returns>
        VolatileObject Self();
        /// <summary>
        /// This method returns the inventory this IPressurisable is using to store the gases involved in pressurisation (so the volume of the open space, as an inventory).
        /// </summary>
        /// <returns>The inventory used for pressurisation.</returns>
        IInventory Inventory();
        /// <summary>
        /// This method returns the volume of gas involved in pressurisation as if it were pressurised, as per usual.
        /// </summary>
        /// <returns>The total volume of gas as if pressurised.</returns>
        Metre3 Volume();
        /// <summary>
        /// This method returns the current pressure of this IPressurisable in pascals.
        /// </summary>
        /// <returns>The current pressure in pascals.</returns>
        Pascal Pressure();
        /// <summary>
        /// This method returns the current temperature of this IPressurisable in kelvin.
        /// </summary>
        /// <returns>The current temperature in kelvin.</returns>
        Kelvin Temperature();
        /// <summary>
        /// This method returns the desired pressure of this IPressurisable in pascals.
        /// </summary>
        /// <returns>The desired pressure in pascals.</returns>
        Pascal DesiredPressure();
        /// <summary>
        /// This method sets the desired pressure of this IPressurisable to the passed pressure in pascals.
        /// </summary>
        /// <param name="pressureTo">The pressure in pascals desired pressure should be set to.</param>
        /// <returns></returns>
        Pascal DesiredPressure(Pascal pressureTo);
    }
}
