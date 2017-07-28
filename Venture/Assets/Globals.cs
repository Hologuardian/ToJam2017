using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Engine.Src;

namespace Assets
{
    public class Globals
    {
        public static Memento<float> SimulationSpeed = new Memento<float>("Globals.simulationSpeed");
    }
}