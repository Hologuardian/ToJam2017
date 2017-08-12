using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.Systems.Src
{
    /// <summary>
    /// ISubsystem is the base interface used in all objects that use a system
    /// </summary>
    public interface ISubsystem<T>
    {
        /// <summary>
        /// Query the state of this ISubsystem
        /// </summary>
        /// <returns>The current state of this ISubsystem</returns>
        T State();

        VolatileObject Self();
    }
}
