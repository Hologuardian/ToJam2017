using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Engine;
using Assets.Engine.Src;

namespace Assets.Station.Src
{
    public class VolatileModule : VolatileObject
    {
        // Properties
        // Ensure proper care is taken to considering which must be Mementos and which can be generic
        /// <summary>
        /// All modules come in 1 of 5 sizes, these sizes are cubes with specific dimensions used in pathfinding, and in space partitioning.
        /// As well these sizes define what tier of station technology this module is.
        /// </summary>
        public Size size = Size.Tiny;
        /// <summary>
        /// The dimensions in cubes of the size specified with the this.size property.
        /// </summary>
        public Vector3 dimensions = new Vector3(1,1,1);

        // Methods
        /// <summary>
        /// Update must be thread safe
        /// </summary>
        public void Update()
        {
            lock (this)
            {
                // TODO generic module logic
                this.OverrideUpdate();
            }
        }

        /// <summary>
        /// This method is the overridable method used to give VolatileModule child classes actual logic, while gauranteeing thread safety, as Update locks this before calling OverrideUpdate
        /// </summary>
        public abstract void OverrideUpdate();
    }
}
