using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Station.Src.Modules
{
    public class VolatileCommandModule : VolatileModule
    {
        public VolatileCommandModule(string name) : base(name)
        {
        }

        public override void OverridableUpdate()
        {
            // Seems simple because
            // Update Sequence logic in the base module logic dictates that if this sequence number is higher than the target modules sequence number than queue an update call on that module
            // Since this update is called before requests are sent, this will always be higher than the surrounding modules, and so long as Update() on this gets called with some regularity
            // This will be sufficient to cause a full update cascade
            updateSequence++;
        }
    }
}
