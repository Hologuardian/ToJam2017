using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;
using Resources;

namespace Assets.Station.Src.Requests
{
    public class UpdateModuleRequest : Request
    {
        public int sequence = 0;
        public VolatileModule source;
        public VolatileHardpoint sourceHardpoint;

        public float energyIn = 0;
        public List<ResourceStack> resourcesIn = new List<ResourceStack>();
        public List<ResourceStack> resourcesOut;

        public override void Do(VolatileObject target)
        {
            // VolatileObject in this case will always be a VolatileModule object
            VolatileModule module = target as VolatileModule;

            // Electricity
            module.EnergyProduction = module.EnergyProduction + energyIn;
            // Distribution
            // Run the resources incoming through the filter again, in-case the module has already been updated by something else, and no longer has the same inventory state
            ResourceStack[] resourcesInUpdated = sourceHardpoint.FilterResourceStackArray(resourcesIn.ToArray());

            // Set up the resourcesOut list
            resourcesOut = new List<ResourceStack>();
            // Go through all the resources coming in
            foreach(ResourceStack stack in resourcesIn)
            {
                // Store the remainder in resourcesOut and add to the inventory
                resourcesOut.Add(module.Inventory.AddResource(stack));
            }
            if (resourcesOut.Count > 0)
            {
                // If any resourcesOut have been added, the source module needs to be updated again to show the update of resources back into their inventory
                sourceHardpoint.Request(new UpdateModuleRequest() { source = source, sourceHardpoint = sourceHardpoint, sequence = sequence, resourcesIn = resourcesOut });
            }
            // Events

        }
    }
}
