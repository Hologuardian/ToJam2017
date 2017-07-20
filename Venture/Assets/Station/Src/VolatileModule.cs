using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;

namespace Assets.Station.Src
{
    public abstract class VolatileModule : VolatileObject
    {
        // Properties
        // Ensure proper care is taken to considering which must be Mementos and which can be generic
        /// <summary>
        /// All modules have a name, this is the name of their table in the database, and their unique name in game data
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// The nonvolatile representation of this module in Unity, this should be accessed carefully, as it will not be locked at anytime, and could be the source of race conditions, especially with Unity.
        /// If you want to do anything to this object you should queue a unity task to do just that, the next time Unity is able.
        /// </summary>
        public Module UnityObject { get; protected set; }
        /// <summary>
        /// All modules come in 1 of 5 sizes, these sizes are cubes with specific dimensions used in pathfinding, and in space partitioning.
        /// As well these sizes define what tier of station technology this module is.
        /// </summary>
        public Size Size { get; protected set; }
        /// <summary>
        /// The dimensions in cubes of the size specified with the this.size property.
        /// </summary>
        public Vector3 Dimensions { get; protected set; }
        /// <summary>
        /// The mass of this module, before any inventory.
        /// </summary>
        public float TrueMass { get; protected set; }
        /// <summary>
        /// The volume this module has for inventory.
        /// </summary>
        public float MaximumVolume { get; protected set; }
        /// <summary>
        /// The maximum pressurisation this module can maintain before suffering structural damage.
        /// </summary>
        public float MaximumPressurisation { get; protected set; }
        /// <summary>
        /// The percentage of incoming power that is lost in travel across this module.
        /// </summary>
        public float LineLoss { get; protected set; }

        // Mementos
        private Memento<float> mass;
        /// <summary>
        /// The current mass of this module, after accounting for inventory.
        /// </summary>
        public float Mass
        {
            get
            {
                return mass;
            }
            protected set
            {
                mass.Set(value);
            }
        }
        private Memento<float> volume;
        /// <summary>
        /// The current volume of this module remaining, after accounting for inventory.
        /// </summary>
        public float Volume
        {
            get
            {
                return volume;
            }
            protected set
            {
                volume.Set(value);
            }
        }
        private Memento<float> pressurisation;
        /// <summary>
        /// The current pressurisation of this module, in pascals.
        /// </summary>
        public float Pressurisation
        {
            get
            {
                return pressurisation;
            }
            protected set
            {
                pressurisation.Set(value);
            }
        }
        private Memento<float> energyProduction;
        public float EnergyProduction
        {
            get
            {
                return energyProduction;
            }
            protected set
            {
                energyProduction.Set(value);
            }
        }
        private Memento<float> energyConsumption;
        /// <summary>
        /// The amount of energy this module consumes per hour in watt hours.
        /// </summary>
        public float EnergyConsumption
        {
            get
            {
                return energyConsumption;
            }
            protected set
            {
                energyConsumption.Set(value);
            }
        }

        public VolatileModule(string name)
        {
            Name = name;

            mass = new Memento<float>(Name + ".mass");
            volume = new Memento<float>(Name + ".volume");
            pressurisation = new Memento<float>(Name + ".pressurisation");
            energyProduction = new Memento<float>(Name + ".energyproduction");
            energyConsumption = new Memento<float>(Name + ".energyconsumption");
        }

        // Methods
        /// <summary>
        /// Update is a thread safe method which locks and calls OverridableUpdate
        /// As well Update performs any general module logic, such as:
        /// Distributing Electricity
        /// Distributing Events
        /// Distributing Resources, given input and output hardpoints
        /// </summary>
        public void Update()
        {
            lock (this)
            {
                // TODO generic module logic
                // First calculate all output values for each hardpoint connection
                // Second send an update down every hardpoint with the necessary outputs
                foreach (Hardpoint hardpoint in UnityObject.hardpoints)
                {
                    // Calculate the output through each hardpoint
                    // Queue hardpoint update, with the necessary inputs
                    
                }

                OverridableUpdate();
            }
        }

        /// <summary>
        /// This method is the overridable method used to give OverridableUpdate child classes actual logic, while gauranteeing thread safety, as Update locks this before calling OverridableUpdate
        /// </summary>
        public abstract void OverridableUpdate();
    }
}
