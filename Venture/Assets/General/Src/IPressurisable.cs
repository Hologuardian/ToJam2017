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
        
    }
}
