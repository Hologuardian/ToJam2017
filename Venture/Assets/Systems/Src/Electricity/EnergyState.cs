using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets;
using Assets.General.Src.SI;

namespace Assets.Systems.Src.Electricity
{
    [Flags]
    public enum Properties { None = 0, Energy = 1, EnergyProduction = 2, EnergyConsumption = 4, EnergyLoss = 8, LineLoss = 16, All = 31 }

    public class EnergyState
    {
        public static Dictionary<Properties, Properties> Dependancies = new Dictionary<Properties, Properties>()
        {
            { Properties.Energy, Properties.EnergyConsumption | Properties.EnergyProduction },
            { Properties.EnergyProduction, Properties.None },
            { Properties.EnergyConsumption, Properties.None},
            { Properties.EnergyLoss, Properties.Energy | Properties.LineLoss },
            { Properties.LineLoss, Properties.None }
        };

        public Properties Dirtied = Properties.None;

        private WattHour energy = 0;
        /// <summary>
        /// Energy represents the current amount of net energy active in this state of the electrical grid sub system.
        /// </summary>
        public WattHour Energy
        {
            get
            {
                if (Dirtied.Has(Properties.Energy))
                    ElectricalGrid.Energy(this);

                return energy;
            }
            set
            {
                energy = value;
                Dirtied.Add(Properties.Energy);
            }
        }
        private WattHour energyProduction = 0;
        /// <summary>
        /// Energy production represents the total amount of energy production per hour of this state of the IEnergyProducer.
        /// </summary>
        public WattHour EnergyProduction
        {
            get
            {
                if (Dirtied.Has(Properties.EnergyProduction))
                    ElectricalGrid.EnergyProduction(this);

                return energyProduction;
            }
            set
            {
                energyProduction = value;
                Dirtied.Add(Properties.EnergyProduction);
            }
        }
        private WattHour energyConsumption = 0;
        /// <summary>
        /// Energy consumption represents the total amount of energy consumed per hour in this state of the IEnergyConsumer.
        /// </summary>
        public WattHour EnergyConsumption
        {
            get
            {
                if (Dirtied.Has(Properties.EnergyConsumption))
                    ElectricalGrid.EnergyConsumption(this);

                return energyConsumption;
            }
            set
            {
                energyConsumption = value;
                Dirtied.Add(Properties.EnergyConsumption);
            }
        }
        private WattHour energyLoss = 0;
        /// <summary>
        /// Energy loss is the predicted WattHour loss from transmitting energy to other connected IEnergyConsumers or IEnergyProducers
        /// </summary>
        public WattHour EnergyLoss
        {
            get
            {
                if (Dirtied.Has(Properties.EnergyLoss))
                    ElectricalGrid.EnergyLoss(this);

                return energyLoss;
            }
            set
            {
                energyLoss = value;
                Dirtied.Add(Properties.EnergyLoss);
            }
        }
        private float lineLoss = 0.05f;
        /// <summary>
        /// Line loss is the percentage of energy lost in transmittion across this electrical grid subsytem.
        /// </summary>
        public float LineLoss
        {
            get
            {
                if (Dirtied.Has(Properties.LineLoss))
                    ElectricalGrid.LineLoss(this);

                return lineLoss;
            }
            set
            {
                lineLoss = value;
                Dirtied.Add(Properties.LineLoss);
            }
        }
    }
}
