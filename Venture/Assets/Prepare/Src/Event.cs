using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine;

namespace Assets.Prepare
{
    public enum Severity { Great = 0, Good = 1, Neutral = 2, Bad = 3, Terrible = 4, Catastrophic = 5 };

    public abstract class Event : Request
    {
        public string Description { get; protected set; }
        public Severity Severity { get; protected set; }
    }
}
