using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets.Station.Src.Requests
{
    /// <summary>
    /// MUST only be used on VolatileObjects which implement an IMemento (I do no checking to make sure)
    /// </summary>
    public class SaveRequest : Request
    {
        public override void Do(VolatileObject target)
        {
            TaskHelper.TaskManager.QueueTask(new TaskNode(((IMemento)target).SaveState, "saveRequest"), (float)TaskPriority.Highest);
        }
    }
}
