using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;
using Resources;

namespace Assets.Station.Src.Requests
{
    public class UpdateModuleRequest : Request
    {
        public int sequence = 0;
        public VolatileModule source;

        public float energyIn = 0;
        public List<ResourceStack> resourcesIn = new List<ResourceStack>();
        public List<ResourceStack> resourcesOut = new List<ResourceStack>();

        public override void Do(VolatileObject target)
        {
            // VolatileObject in this case will always be a VolatileModule object
            VolatileModule module = target as VolatileModule;

            // Electricity
            module.EnergyProduction = module.EnergyProduction + energyIn;
            // Distribution
            foreach(ResourceStack stack in resourcesIn)
            {
                resourcesOut.Add(module.Inventory.AddResource(stack));
            }
            // Events

        }
    }
}
