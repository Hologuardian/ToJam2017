using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets;
using Assets.General.Src.SI;

namespace Assets.Systems.Src.Electricity
{
    public class EnergyState
    {
        public Guid production;
        public Guid consumption;

        public WattHour energy = 0;
        public WattHour energyProduction = 0;
        public WattHour energyConsumption = 0;
        public WattHour energyLoss = 0;
        public float lineLoss = 0.05f;
    }
}
