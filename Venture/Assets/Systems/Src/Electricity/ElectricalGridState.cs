using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets;
using Assets.General.SI;

namespace Assets.Systems.Electricity
{
    public struct ElectricalGridState : IState
    {
        public string name;
        public int update;

        public Guid production;
        public Guid consumption;

        public WattHour energy;
        public WattHour energyProduction;
        public WattHour energyConsumption;
        public WattHour energyLoss;
        public float lineLoss;

        public object[] Parameters()
        {
            return new object[] { name, update, production, consumption, energy, energyProduction, energyConsumption, energyLoss, lineLoss };
        }
    }
}
