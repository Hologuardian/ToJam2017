using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;
using Assets.General.Src;
using Assets.General.Src.SI;
using Assets.Station.Src.Requests;
using Resources;

namespace Assets.Station.Src
{
    public struct VolatileModuleState
    {
        public int timestamp;
        public int updateSequence;
        //UNCHANGING public string name;
        //UNCHANGING public Module module;
        //UNCHANGING public Size size;
        //UNCHANGING public Vector3 dimensions;
        public Metre3 volume;
        public WattHour energyProduction;
        public float energyTransferRate;
        public float structuralIntegrity;
        public float structuralIntegrityMax;
        public Pascal pressurisation;
        public int occupants;
        public int occupantsMax;

        public VolatileModuleState(VolatileModule self)
        {
            updateSequence = self.updateSequence;
            volume = self.volume;
            energyProduction = self.energyProductionTotal;
            self.energyProductionTotal = 0;
            energyTransferRate = self.energyTransferRate;
            structuralIntegrity = self.structuralIntegrity;
            structuralIntegrityMax = self.structuralIntegrityMax;
            pressurisation = self.pressurisation;
            occupants = self.occupants;
            occupantsMax = self.occupantsMax;
            timestamp = DateTime.Now.Millisecond;
        }
    }

    public abstract class VolatileModule : VolatileObject, IMemento
    {
        // Properties
        // Ensure proper care is taken to considering which must be Mementos and which can be generic
        public int updateSequence = 0;
        /// <summary>
        /// All modules have a name, this is the name of their table in the database, and their unique name in game data
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// The nonvolatile representation of this module in Unity.
        /// </summary>
        /// <remark>
        /// This should be accessed carefully, as it will not be locked at anytime, and could be the source of race conditions, especially with Unity. If you want to do anything to this object you should queue a unity task to do just that, the next time Unity is able.
        /// </remark>
        public Module UnityObject { get; protected set; }
        /// <summary>
        /// All modules come in 1 of 5 sizes, these sizes are cubes with specific dimensions used in pathfinding, and in space partitioning.
        /// As well these sizes define what tier of station technology this module is.
        /// </summary>
        public Size Size { get; protected set; }
        /// <summary>
        /// The dimensions in cubes of the size specified with the this.Size property.
        /// </summary>
        public Vector3 Dimensions { get; protected set; }
        /// <summary>
        /// The mass of this module.
        /// </summary>
        public Gram mass;
        /// <summary>
        /// The mass of this module, including inventory.
        /// </summary>
        public Gram Mass { get { return mass /*TODO Mark I need this: + Inventory.CurrentMass()*/; } }
        /// <summary>
        /// The volume this module has for inventory.
        /// </summary>
        public Metre3 volume;
        /// <summary>
        /// The volume remaining in this module after all items in the inventory have been accounted for
        /// </summary>
        public Metre3 Volume { get { return volume - Inventory.CurrentVolume(); } }
        /// <summary>
        /// The amount of power this module produces per hour in watt hours (negative in cases of power consumption).
        /// </summary>
        public WattHour energyProduction;
        /// <summary>
        /// The amount of power this module has produced (or consumed) since its last save state (in sim hourly)
        /// </summary>
        public WattHour energyProductionTotal;
        /// <summary>
        /// The percentage of incoming power that is kept in travel across this module.
        /// </summary>
        public float energyTransferRate { get; protected set; }
        /// <summary>
        /// Structural Integrity is the measure of damage this module has received.
        /// </summary>
        public float structuralIntegrity;
        /// <summary>
        /// Defines the maximum amount of structural integrity this module has.
        /// </summary>
        public float structuralIntegrityMax;
        /// <summary>
        /// The current pressurisation of this module, in pascals.
        /// </summary>
        public Pascal pressurisation;
        /// <summary>
        /// The maximum pressurisation this module can maintain before suffering structural damage.
        /// </summary>
        public Pascal pressurisationMax;
        /// <summary>
        /// The current number of occupants this module has.
        /// </summary>
        public int occupants;
        /// <summary>
        /// The maximum number of occupants this module can have before suffering structural damage.
        /// </summary>
        public int occupantsMax;
        /// <summary>
        /// The inventory of costs necessary to build this module.
        /// Also used for repairs.
        /// </summary>
        public IInventory CostOfConstruction;
        /// <summary>
        /// The resource costs to run this module.
        /// This inventory has its amounts set by any module behaviours.
        /// </summary>
        public IInventory CostOfOperation;
        /// <summary>
        /// The inventory interface of this module.
        /// </summary>
        public IInventory Inventory;

        public VolatileModule(string name)
        {
            Name = name;

            //mass = new Statistic(Name + ".mass", 1, 0);
            //Volume = new Statistic(Name + ".volume", 1, 0);
            //EnergyProduction = new Memento<WattHour>(Name + ".energyproduction");
            //StructuralIntegrity = new Statistic(Name + ".structuralIntegrity", 1, 0);
            //Pressurisation = new Statistic(Name + ".pressurisation", 1, 0);
            //Occupants = new Statistic(Name + ".occupants", 1, 0);
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
            //lock (this)
            //{
            // This VolatileObject is currently locked by the threaded environment, and its properties are being accessed
            //state = State.Locked | State.Threaded | State.Accessed;

            // RESET ----------------------------------------------------------------------------------
            // Reset all parameters that reset every update
            //EnergyProduction.Set(0);
            energyProduction = 0;

            // REQUESTS -------------------------------------------------------------------------------
            foreach (Hardpoint hardpoint in UnityObject.hardpoints)
            {
                // This prevents any race conditions
                //lock (hardpoint.threaded)
                //{
                //hardpoint.threaded.state = State.Locked | State.Threaded | State.Accessed;
                // Take all the requests from the hardpoint
                for (int i = 0; i < hardpoint.threaded.RequestCount; i++)
                {
                    hardpoint.threaded.Pop().Do(this);
                }

                // Clear the hardpoints requests
                hardpoint.threaded.Clear();

                // Reset the changes
                //hardpoint.threaded.state = State.None;
                //}
            }

            // Process all the requests
            for (int i = 0; i < RequestCount; i++)
            {
                Pop().Do(this);
            }

            // MODULE ---------------------------------------------------------------------------------
            OverridableUpdate();

            // SUBMODULES -----------------------------------------------------------------------------
            foreach (Submodule sub in UnityObject.submodules)
            {
                // TODO Submodule Update
            }

            // HARDPOINTS -----------------------------------------------------------------------------
            // First calculate all output values for each hardpoint connection
            // Second send an update down every hardpoint with the necessary outputs
            foreach (Hardpoint hardpoint in UnityObject.hardpoints)
            {
                if (hardpoint.connection != null)
                {
                    // Each hardpoint connection queues UpdateModuleRequests on the other modules hardpoint
                    UpdateModuleRequest newRequest = new UpdateModuleRequest();
                    newRequest.source = this;
                    newRequest.sourceHardpoint = hardpoint.threaded;

                    // Calculate the output through each hardpoint
                    // Electricity
                    // If the connected module has higher PowerProduction than this one then don't send power (you are probably recieving power from it anyways)
                    if (hardpoint.connection.module.threaded.energyProduction < energyProduction)
                        newRequest.energyIn = Mathf.Max((WattHour)energyProduction * energyTransferRate, 0);

                    // Distribution
                    newRequest.resourcesIn.AddRange(hardpoint.threaded.FilterInventory(Inventory));

                    // Queue hardpoint update, with the necessary inputs
                    hardpoint.connection.threaded.Request(newRequest);

                    // If the connected hardpoints module has a lower update sequence than this one,
                    if (hardpoint.connection.module.threaded.updateSequence < updateSequence)
                    {
                        hardpoint.connection.module.threaded.updateSequence = updateSequence;
                        // TODO Fix string literal
                        TaskHelper.TaskManager.QueueTask(new TaskNode(hardpoint.connection.module.threaded.Update, "moduleUpdate"), (float)TaskPriority.Medium);
                    }
                }
            }

            // LASTPASS ------------------------------------------------------------------------------
            // All the final updates to ensure that user data is correct
            
            //state = State.None;
            //}
        }

        /// <summary>
        /// This method is the overridable method used to give OverridableUpdate child classes logic
        /// </summary>
        public abstract void OverridableUpdate();

        // IMemento ----------------------------------------------------------------------------------
        public void SaveState()
        {
            // I need to create a new save state for this volatilemodule
        }

        public void LoadState()
        {
            // I need to load the latest save state for this volatilemodule
        }

        public void DumpState()
        {
            // I need to dump the save states in memory to storage
        }
    }
}
