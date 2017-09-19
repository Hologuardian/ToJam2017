using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine;
using Assets.General.Src;
using Assets.General.SI;
using Assets.Resources.Src;
using Assets.Station.Requests;

namespace Assets.Station
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
            // TODO IInventory SaveState()
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
        public Module unityObject { get; protected set; }
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
        public Gram Mass { get { return mass + Inventory.TotalMass(); } }
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
        /// The temperature in degrees kelvin of this module.
        /// </summary>
        public Kelvin temperature;
        /// <summary>
        /// The maximum temperature this module can maintain before suffering structural damage.
        /// </summary>
        public Kelvin temperatureMax;
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
        /// The resources to fill the module with (gaseous).
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
            energyProductionTotal += energyProduction;
            energyProduction = 0;

            // REQUESTS -------------------------------------------------------------------------------
            foreach (Hardpoint hardpoint in unityObject.hardpoints)
            {
                // Take all the requests from the hardpoint
                for (int i = 0; i < hardpoint.volatileHardpoint.RequestCount; i++)
                {
                    hardpoint.volatileHardpoint.Pop().Do(this);
                }
            }

            // Process all the requests
            for (int i = 0; i < RequestCount; i++)
            {
                Pop().Do(this);
            }

            // MODULE ---------------------------------------------------------------------------------
            OverridableUpdate();

            // SUBMODULES -----------------------------------------------------------------------------
            foreach (Submodule sub in unityObject.submodules)
            {
                sub.volatileSubmodule.Update();
            }

            // This establishes the number of hardpoints requiring power output.
            float hardpointsNeedingPower = 0;
            foreach(Hardpoint hardpoint in unityObject.hardpoints)
            {
                if (hardpoint.connection.module.volatileObject.energyProduction < energyProduction)
                    hardpointsNeedingPower++;
            }

            // HARDPOINTS -----------------------------------------------------------------------------
            // First calculate all output values for each hardpoint connection
            // Second send an update down every hardpoint with the necessary outputs
            foreach (Hardpoint hardpoint in unityObject.hardpoints)
            {
                if (hardpoint.connection != null)
                {
                    // Each hardpoint connection queues UpdateModuleRequests on the other modules hardpoint
                    UpdateModuleRequest newRequest = new UpdateModuleRequest();
                    newRequest.source = this;
                    newRequest.sourceHardpoint = hardpoint.volatileHardpoint;

                    // Calculate the output through each hardpoint
                    // Electricity
                    // If the connected module has lower energy production than this one then send power
                    // Using the previously calculated hardpointsNeedingPower we can ensure that all the hardpoints in need get some
                    if ((float)hardpoint.connection.module.volatileObject.energyProduction < (float)energyProduction)
                        newRequest.energyIn = Mathf.Max(((float)energyProduction / hardpointsNeedingPower) * energyTransferRate, 0);

                    // Integrity
                    // TODO (Late) Implement technology that allows modules to repair each other via connections alone.
                    //if (hardpoint.connection.module.threaded.structuralIntegrity < hardpoint.connection.module.threaded.structuralIntegrityMax && structuralIntegrity >= structuralIntegrityMax)
                    //    newRequest.structuralIntegrityIn = Mathf.Max(SOME_VARIABLE_FOR_REPAIR_FIELD_STRENTH * structuralIntegrity, SOME_VARIABLE_FOR_MAXIMUM_REPAIR_STRENGTH);

                    // Pressurisation
                    // If this module has the resources necessary to increase the pressurisation of the connected module, it should send some, either from its pressurisationGasses inventory (first)
                    // Or from its inventory proper (second).
                    if ((float)hardpoint.connection.module.volatileObject.pressurisation < (float)hardpoint.connection.module.volatileObject.pressurisationDesired)
                    {
                        // If this module is more pressurised than it should be, take from the pressurisationGasses
                        if ((float)pressurisation > (float)pressurisationDesired)
                        {
                            // Calculate how much volume we can take based on the pressure from the pressurisationGasses inventory
                        }
                        // Take the rest if any more is necessary, from inventory, if it has any                    
                    }

                    // Distribution
                    // Need to take into account the number of output hardpoints that want to output the same resourcestacks, as they need to split the current amount between them, if between them they would take more than there is
                    if ((hardpoint.volatileHardpoint.direction & VolatileHardpoint.Direction.Output) != VolatileHardpoint.Direction.None)
                    {
                        // Get all the desired resources by filtering the module inventory through the hardpoint inventory, returning only those that both inventories have in common
                        ResourceStack[] desiredResources = hardpoint.volatileHardpoint.FilterInventory(Inventory);
                        // A temporary array of values indicating the total number of hardpoints desiring the resource in desiredResources at the same index
                        int[] desiredHardpoints = new int[desiredResources.Length];
                        
                        // This will fill desiredHardpoints with the number of hardpoints desiring each resource in desiredResources, so as to evenly distribute between all hardpoints
                        // As is the case whenever the total amount desired by hardpoints exceeds the amount remaining in this module.
                        // Iterate across the hardpoints
                        foreach(Hardpoint other in unityObject.hardpoints)
                        {
                            if ((other.volatileHardpoint.direction & VolatileHardpoint.Direction.Output) != VolatileHardpoint.Direction.None)
                            {
                                // Iterate across the desiredResources
                                for (int i = 0; i < desiredResources.Length; i++)
                                {
                                    // If the hardpoint wants the desiredResource increment the index of desiredHardpoints matching the index of desiredResource
                                    if ((float)other.volatileHardpoint.Filter.GetResource(desiredResources[i].type).volume == 0)
                                    {
                                        desiredHardpoints[i]++;
                                    }
                                }
                            }
                        }

                        // The reason for this section of logic is to ensure that no one resource stack desired is taking more from this module than it has
                        // And than the module the resources are going to can take
                        Metre3 desiredVolume = 0;

                        foreach (ResourceStack stack in desiredResources)
                        {
                            desiredVolume += stack.volume;
                        }

                        // Iterate across the desiredResources
                        for (int i = 0; i < desiredResources.Length; i++)
                        {
                            // Get the ResourceStack in question from the Inventory
                            ResourceStack invResource = Inventory.GetResource(desiredResources[i].type);

                            // If the total amount desired is greater than the volume of the amount this module has
                            if (desiredResources[i].volume * desiredHardpoints[i] > invResource.volume)
                            {
                                desiredVolume -= desiredResources[i].volume;
                                // Set the amount desired to the total volume this module has divided by the number of hardpoints wanting it
                                desiredResources[i].volume = invResource.volume / desiredHardpoints[i];
                                desiredVolume += desiredResources[i].volume;
                            }
                            
                            // Module Distribution based on the remaining space in the module this resource is being sent to
                            if (desiredVolume > hardpoint.connection.module.volatileObject.Volume)
                            {
                                // The logic here is that instead of attempting to send the desired amount of everything, we instead only send the percentage of that stuff as a total of all the stuff being sent
                                // And send only that percentage of the volume remaining in the module, that way whatever amounts we wanted to distribute, we maintain the percentage volume, but fill the module, instead of having whatever filled it first, fill it first.
                                // The only issue with this system, is that ultimately it doesn't take into account other pending, or will be pending by module update, requests, and they will therefore still have a first come first serve bases between several modules inputing on one module
                                desiredResources[i].volume = (desiredResources[i].volume / desiredVolume) * hardpoint.connection.module.volatileObject.Volume;
                            }
                            newRequest.resourcesIn.Add(desiredResources[i]);
                        }
                    }

                    // Queue hardpoint update, with the necessary inputs
                    hardpoint.connection.volatileHardpoint.Request(newRequest);

                    // If the connected hardpoints module has a lower update sequence than this one
                    // Queue an update of the module (this is the basis of the whole sequenced update system)
                    if (hardpoint.connection.module.volatileObject.updateSequence < updateSequence)
                    {
                        hardpoint.connection.module.volatileObject.updateSequence = updateSequence;
                        TaskHelper.TaskManager.QueueTask(new TaskNode(hardpoint.connection.module.volatileObject.Update, Literals.Tasks.UpdateModule), (float)TaskPriority.Medium);
                    }
                }
            }

            // LASTPASS ------------------------------------------------------------------------------
            // All the final updates to ensure that user data is correct
        }

        /// <summary>
        /// This method is the overridable method used to give child classes logic
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
