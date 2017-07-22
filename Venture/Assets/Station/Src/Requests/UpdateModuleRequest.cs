using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.Station.Src.Requests
{
    public class UpdateModuleRequest : Request
    {
        public float energyIn = 0;
        //public float 

        public override void Do(VolatileObject target)
        {
            // VolatileObject in this case will always be a VolatileModule object
            VolatileModule module = target as VolatileModule;

            // Electricity
            module.EnergyProduction = module.EnergyProduction + energyIn;
            // Distribution

            // Events

        }
    }
}
