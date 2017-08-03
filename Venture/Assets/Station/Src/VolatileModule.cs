using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;
using Assets.General.Src;
using Assets.General.Src.SI;
using Assets.Resources.Src;
using Assets.Station.Src.Requests;

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
        public Pascal pressurisationDesired;
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
            pressurisationDesired = self.pressurisationDesired;
            occupants = self.occupants;
            occupantsMax = self.occupantsMax;
            // TODO Inventory SaveState()
            // if (self.pressurisation > 0) { self.pressurisationGasses.SaveState(); }
            // self.Inventory.SaveState();
            // self.CostOfOperation.SaveState();
            timestamp = DateTime.Now.Millisecond;
        }
    }

    public abstract class VolatileModule : VolatileObject, IMemento
    {
        // Properties
        private List<VolatileModuleState> states = new List<VolatileModuleState>();
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
        /// The desired pressurisation of this module.
        /// </summary>
        public Pascal pressurisationDesired;
        /// <summary>
        /// The desired resources to fill the module with (gaseous).
        /// </summary>
        public IInventory pressurisationGasses;
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
            // RESET ----------------------------------------------------------------------------------
            // Reset all parameters that reset every update
            energyProductionTotal.Value += energyProduction;
            energyProduction = 0;

            // REQUESTS -------------------------------------------------------------------------------
            foreach (Hardpoint hardpoint in UnityObject.hardpoints)
            {
                // Take all the requests from the hardpoint
                for (int i = 0; i < hardpoint.threaded.RequestCount; i++)
                {
                    hardpoint.threaded.Pop().Do(this);
                }

                // Clear the hardpoints requests
                hardpoint.threaded.Clear();
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
                    // If the connected module has lower energy production than this one then send power
                    if (hardpoint.connection.module.threaded.energyProduction < energyProduction)
                        newRequest.energyIn = Mathf.Max(energyProduction * energyTransferRate, 0);

                    // Integrity
                    // TODO (Late) Implement technology that allows modules to repair each other via connections alone.
                    //if (hardpoint.connection.module.threaded.structuralIntegrity < hardpoint.connection.module.threaded.structuralIntegrityMax && structuralIntegrity >= structuralIntegrityMax)
                    //    newRequest.structuralIntegrityIn = Mathf.Max(SOME_VARIABLE_FOR_REPAIR_FIELD_STRENTH * structuralIntegrity, SOME_VARIABLE_FOR_MAXIMUM_REPAIR_STRENGTH);

                    // Pressurisation
                    // IDEAL GAS LAW = PV=nRT
                    // Where:
                    // P = pressure in atm.
                    // n = moles of gas
                    // R = ideal gas constant (0.08206)
                    // T = temperature in kelvin
                    // V = volume in litres

                    // TODO determine logic to convert Mark's highly pressurised gases to standard pressures, like 101.325kPa (1 atm).
                    // Modified Ideal Gas Law to solve for Pressure in Atm
                    // P = nRT/V
                    // If this module has a pressurisation greater than or equal to its desired pressurisation
                    // If connected module has a pressurisation less than its desired pressurisation
                    // Send some gas

                    // Okay so this is actually a 2 fold problem.
                    // Mark has pressurised the gasses to essentially random hundred value bar pressurisations
                    // Which means I need to determine the volume of gas after depressurisation before I can use it
                    // Which is done like so:
                    // V = nRT/P
                    // Refer to the above pressurisation equation for variables
                    // And I need to convert Bar to Atmospheres (101.325kPa)

                    // This needs to have Mark's resources using the new SI unit system first though, that way I can just have the conversions occur automatically.

                    // Distribution
                    if ((hardpoint.threaded.direction & VolatileHardpoint.Direction.Output) != VolatileHardpoint.Direction.None)
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
        }

        /// <summary>
        /// This method is the overridable method used to give OverridableUpdate child classes logic
        /// </summary>
        public abstract void OverridableUpdate();

        // IMemento ----------------------------------------------------------------------------------
        public virtual void SaveState()
        {
            // I need to create a new save state for this volatilemodule
            states.Add(new VolatileModuleState(this));
        }

        public virtual void LoadState()
        {
            // I need to load the latest save state for this volatilemodule
        }

        public virtual void DumpState()
        {
            // I need to dump the save states in memory to storage
        }
    }
}
