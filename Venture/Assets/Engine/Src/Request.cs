using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Engine.Src
{
    /// <summary>
    /// Request is the formal means of communicating between 2 volatile objects, 
    /// instead of attempting to modify the others parameters directly (which can cause race conditions) these allow the other to update its parameters itself the next time it updates
    /// </summary>
    public abstract class Request
    {
        /// <summary>
        /// Do executes request logic (such as setting parameters on the volatile object)
        /// </summary>
        /// <param name="target">The volatile object this request is Doing on</param>
        public abstract void Do(VolatileObject target);
    }
}
