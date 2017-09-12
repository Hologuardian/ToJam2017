using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;

namespace Assets.Station.Src.Requests
{
    public class UpdateModuleRequest : Request
    {
        /// <summary>
        /// The sequence number of this UpdateModuleRequest, as each module will recieve many update requests, but only update requests with a higher sequence number should cause an update
        /// </summary>
        public int sequence = 0;
        /// <summary>
        /// The source module this update request comes from
        /// </summary>
        public VolatileModule source;
        /// <summary>
        /// The source hardpoint this update request comes from
        /// </summary>
        public VolatileHardpoint sourceHardpoint;

        /// <summary>
        /// The amount of energy being sent in watthours to the module
        /// </summary>
        public WattHour energyIn = 0;
        public float structuralIntegrityIn = 0;
        //public Pascal pressurisationIn = 0;
        public List<ResourceStack> pressurisationGassesIn = new List<ResourceStack>();
        /// <summary>
        /// The resource stacks being sent to the module
        /// </summary>
        public List<ResourceStack> resourcesIn = new List<ResourceStack>();
        /// <summary>
        /// The resource stacks being sent back to the source module
        /// </summary>
        public List<ResourceStack> resourcesOut;

        public override void Do(VolatileObject target)
        {
            // VolatileObject in this case will always be a VolatileModule object
            VolatileModule module = target as VolatileModule;

            // Electricity
            module.energyProduction += energyIn;

            // Integrity
            module.structuralIntegrity += structuralIntegrityIn;

            // Pressurisation
            //module.pressurisation.Value += pressurisationIn;
            module.pressurisationGasses.AddResources(pressurisationGassesIn.ToArray());

            // Distribution
            // Set up the resourcesOut list
            resourcesOut = new List<ResourceStack>();
            // Get the remaining resources after the attempt to add them may not successfully add them all.
            resourcesOut.AddRange(module.Inventory.AddResources(resourcesIn.ToArray()));

            if (resourcesOut.Count > 0)
            {
                // If any resourcesOut have been added, the source module needs to be updated again to show the update of resources back into their inventory
                sourceHardpoint.Request(new UpdateModuleRequest() { source = source, sourceHardpoint = sourceHardpoint, sequence = sequence, resourcesIn = resourcesOut });
            }
        }
    }
}
