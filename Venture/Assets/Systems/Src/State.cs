using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Systems.Src
{
    /// <summary>
    /// State is the root of all state classes, and as such stores all common logic.
    /// Like Dirty(), though child classes define what makes them dirty at their own discretion.
    /// </summary>
    public class State
    {
        private string name = "";
        public string Name { get { return name; } set { name = value; Dirty = true; } }

        public State(string name)
        {
            this.name = name;
        }
    }
}
