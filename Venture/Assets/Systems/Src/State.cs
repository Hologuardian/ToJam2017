using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Src
{
    /// <summary>
    /// State is the root of all state classes
    /// </summary>
    public class State
    {
        public string name = "";
        public int update = 0;

        public State(string name, int update)
        {
            this.name = name;
            this.update = update;
        }
    }
}
