using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine;
using Assets.General.SI;

namespace Assets.Station.Modules
{
    public class VolatileRingModule : VolatileModule
    {
        public VolatileRingModule(string name) : base(name)
        {
        }

        public override void OverridableUpdate()
        {
            
        }

        public override void SaveState()
        {
            // TODO extend savestate functionality to reflect new variables to save on VolatileRingModule
            base.SaveState();
        }
    }
}
