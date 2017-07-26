using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Engine.Src;
using Assets.Station.Src.Requests;
using Resources;

namespace Assets.Station.Src
{
    public abstract class VolatileModule : VolatileObject
    {
        // Properties
        // Ensure proper care is taken to considering which must be Mementos and which can be generic
        public int updateSequence = 0;
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
        /// The dimensions in cubes of the size specified with the this.Size property.
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
        /// The percentage of incoming power that is kept in travel across this module.
        /// </summary>
        public float LineLoss { get; protected set; }
        /// <summary>
        /// The inventory interface of this module.
        /// </summary>
        public IInventory Inventory;

        // Mementos
        /// <summary>
        /// The current mass of this module, after accounting for inventory.
        /// </summary>
        public Memento<float> Mass;
        /// <summary>
        /// The current volume of this module remaining, after accounting for inventory.
        /// </summary>
        public Memento<float> Volume;
        /// <summary>
        /// The current pressurisation of this module, in pascals.
        /// </summary>
        public Memento<float> Pressurisation;
        /// <summary>
        /// The amount of energy this module produces per hour in watt hours (negative in cases of power consumption).
        /// </summary>
        public Memento<float> EnergyProduction;

        public VolatileModule(string name)
        {
            Name = name;

            Mass = new Memento<float>(Name + ".mass");
            Volume = new Memento<float>(Name + ".volume");
            Pressurisation = new Memento<float>(Name + ".pressurisation");
            EnergyProduction = new Memento<float>(Name + ".energyproduction");
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
                EnergyProduction.Set(0);

                // REQUESTS -------------------------------------------------------------------------------
                // First, all update requests, as well as a variety of others come from the hardpoints, in this manner one module speaks to the other's hardpoints locking them
                // Since each talks to the other's, this allows for 2 way dialogue without causing either to lock the other with direct module to module access.
                // To do that we need to get all the hardpoint requests from this object, and ensure this module has them in its requests.
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
                foreach(Submodule sub in UnityObject.submodules)
                {
                    // TODO Submodule Update
                }

                // HARDPOINTS -----------------------------------------------------------------------------
                // First calculate all output values for each hardpoint connection
                // Second send an update down every hardpoint with the necessary outputs
                foreach (Hardpoint hardpoint in UnityObject.hardpoints)
                {
                    // Each hardpoint connection queues UpdateModuleRequests on the other modules hardpoint
                    UpdateModuleRequest newRequest = new UpdateModuleRequest();
                    newRequest.source = this;
                    newRequest.sourceHardpoint = hardpoint.threaded;

                    // Calculate the output through each hardpoint
                    // Electricity
                    // If the connected module has higher EnergyProduction than this one then don't send power (you are probably recieving power from it anyways)
                    if (hardpoint.connection.module.threaded.EnergyProduction < EnergyProduction)
                        newRequest.energyIn = Mathf.Max(EnergyProduction * LineLoss, 0);

                    // Distribution
                    // TODO Distribution based on volume remaining in target module
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

                // LASTPASS ------------------------------------------------------------------------------
                // All the final updates to ensure that user data is correct

                //state = State.None;
            //}
        }

        /// <summary>
        /// This method is the overridable method used to give OverridableUpdate child classes logic, while gauranteeing thread safety, as Update locks this before calling OverridableUpdate
        /// </summary>
        public abstract void OverridableUpdate();
    }
}
